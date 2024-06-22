using Godot;
using Mattoha.Nodes;

namespace MattohaTut;
public partial class MainMenu : Control
{

	public override void _Ready()
	{
		MattohaSystem.Instance.Client.ConnectedToServer += OnConnected;
		base._Ready();
	}

	private void OnConnected()
	{
		GD.Print("Client connected to server");
		GetTree().ChangeSceneToFile("res://csharp_demo_example/scenes/user_dialog.tscn");
	}


	void OnServerButtonPressed()
	{
		MattohaSystem.Instance.StartServer();
		GetTree().ChangeSceneToFile("res://csharp_demo_example/multiplayer/GameHolder.tscn");
	}

	void OnClientButtonPressed()
	{
		MattohaSystem.Instance.StartClient();
	}

	public override void _ExitTree()
	{
		MattohaSystem.Instance.Client.ConnectedToServer -= OnConnected;
		base._ExitTree();
	}
}
