using Godot;
using Godot.Collections;
using Mattoha.Nodes;
using System;


namespace MattohaTut;
public partial class CreateLobby : Control
{

	[Export] LineEdit LobbyNameInput { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MattohaSystem.Instance.Client.CreateLobbySucceed += OnCreateLobby;
	}

	private void OnCreateLobby(Dictionary<string, Variant> lobbyData)
	{
		GD.Print("Created Lobby: ", lobbyData);
		GetTree().ChangeSceneToFile("res://csharp_demo_example/scenes/lobby.tscn");
	}

	void OnContinueButtonPressed()
	{
		var lobbyData = new Dictionary<string, Variant>
		{
			{ "Name", LobbyNameInput.Text },
			{ "MaxPlayers", 4 },
		};

		MattohaSystem.Instance.Client.CreateLobby(lobbyData, "res://csharp_demo_example/scenes/game.tscn");
	}

	public override void _ExitTree()
	{
		MattohaSystem.Instance.Client.CreateLobbySucceed -= OnCreateLobby;
		base._ExitTree();
	}
}
