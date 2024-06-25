using Godot;
using Godot.Collections;
using Mattoha.Nodes;
using System;


namespace MattohaTut;
public partial class Lobbies : Control
{

	[Export] VBoxContainer LobbiesContainer { get; set; }
	[Export] PackedScene LobbySlotScene { get; set; }


	public override void _Ready()
	{
		MattohaSystem.Instance.Client.LoadAvailableLobbiesSucceed += OnLoadLobbies;
		MattohaSystem.Instance.Client.JoinLobbySucceed += OnJoinLobby;
		MattohaSystem.Instance.Client.LoadAvailableLobbies();
		base._Ready();
	}

	private void OnJoinLobby(Dictionary<string, Variant> lobbyData)
	{
		GetTree().ChangeSceneToFile("res://csharp_demo_example/scenes/lobby.tscn");
	}

	private void OnLoadLobbies(Array<Dictionary<string, Variant>> lobbies)
	{
		GD.Print("Lobbies: ", lobbies);
		foreach (var child in LobbiesContainer.GetChildren())
		{
			child.QueueFree();
		}

		foreach (var lobby in lobbies)
		{
			var slot = LobbySlotScene.Instantiate<LobbySlot>();
			slot.Lobby = lobby;
			LobbiesContainer.AddChild(slot);
		}
	}

	void OnCreateLobbyButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://csharp_demo_example/scenes/create_lobby.tscn");
	}


	public override void _ExitTree()
	{
		MattohaSystem.Instance.Client.LoadAvailableLobbiesSucceed -= OnLoadLobbies;
		MattohaSystem.Instance.Client.JoinLobbySucceed -= OnJoinLobby;
		base._ExitTree();
	}
}
