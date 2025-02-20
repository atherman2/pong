using Godot;
using System;
using System.IO;

public partial class GameManager : Node
{
	[Export] protected StartMenu startMenu;
	[Export] protected PackedScene playMenuScene, pvpScene, easyScene, mediumScene, hardScene;
	protected PlayMenu playMenu;
	protected BaseGame pvpGame, easyGame, mediumGame, hardGame;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void OnPlayPressed()
	{
		startMenu.QueueFree();
		playMenu = (PlayMenu) playMenuScene.Instantiate();
		AddChild(playMenu);
		playMenu.PvpButtonPressed += OnPvpPressed;
	}

	public void OnPvpPressed()
	{
		playMenu.QueueFree();
		pvpGame = (BaseGame) pvpScene.Instantiate();
		AddChild(pvpGame);
	}
}
