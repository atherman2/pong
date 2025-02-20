using Godot;
using System;

public partial class StartMenu : Control
{
	[Signal] public delegate void PlayPressedEventHandler();
	[Export] protected Button playButton, settingsButton, quitButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		playButton.Pressed += OnPlayPressed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void OnPlayPressed()
	{
		EmitSignal(SignalName.PlayPressed);
	}
}
