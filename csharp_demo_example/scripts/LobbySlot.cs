using Godot;
using Godot.Collections;
using Mattoha.Nodes;


namespace MattohaTut;
public partial class LobbySlot : HBoxContainer
{
	[Export] Label LobbyNameLabel { get; set; }
	[Export] Label PlayersCountLabel { get; set; }

	public Dictionary<string, Variant> Lobby { get; set; }


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		LobbyNameLabel.Text = Lobby["Name"].AsString();
		PlayersCountLabel.Text = $"{Lobby["PlayersCount"].AsInt32()} / {Lobby["MaxPlayers"].AsInt32()}";
	}

	void OnJoinButtonPressed()
	{
		MattohaSystem.Instance.Client.JoinLobby(Lobby["Id"].AsInt32());
		GD.Print("Joining lobby: ", Lobby); ;
	}

}
