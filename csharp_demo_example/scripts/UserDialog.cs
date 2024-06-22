using Godot;
using Godot.Collections;
using Mattoha.Nodes;
using System;

namespace MattohaTut;
public partial class UserDialog : Control
{

	[Export] LineEdit UsernameInput { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MattohaSystem.Instance.Client.SetPlayerDataSucceed += OnPlayerDataSet;
	}

	private void OnPlayerDataSet(Dictionary<string, Variant> playerData)
	{
		GD.Print("New Player data: ", playerData);
		GetTree().ChangeSceneToFile("res://csharp_demo_example/scenes/lobbies.tscn");
	}

	private void OnContinueButtonPressed()
	{
		GD.Print("Username: ", UsernameInput.Text);

		var data = new Dictionary<string, Variant>{
			{ "Username", UsernameInput.Text },
			{ "Age", 55 },
		};

		MattohaSystem.Instance.Client.SetPlayerData(data);
	}
}
