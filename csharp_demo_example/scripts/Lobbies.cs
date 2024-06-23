using Godot;
using Godot.Collections;
using Mattoha.Nodes;
using System;


namespace MattohaTut;
public partial class Lobbies : Control
{

	[Export] VBoxContainer LobbiesContainer { get; set; }


	public override void _Ready()
	{
		MattohaSystem.Instance.Client.LoadAvailableLobbiesSucceed += OnLoadLobbies;
		MattohaSystem.Instance.Client.LoadAvailableLobbies();
		base._Ready();
	}

	private void OnLoadLobbies(Array<Dictionary<string, Variant>> lobbies)
	{
		GD.Print("Lobbies: ", lobbies);
	}

	void OnCreateLobbyButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://csharp_demo_example/scenes/create_lobby.tscn");
	}


	public override void _ExitTree()
	{
		MattohaSystem.Instance.Client.LoadAvailableLobbiesSucceed -= OnLoadLobbies;
		base._ExitTree();
	}
}
