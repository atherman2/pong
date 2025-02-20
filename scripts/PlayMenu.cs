using Godot;
using System;

public partial class PlayMenu : Control
{
	[Signal] public delegate void PvpButtonPressedEventHandler();
	[Export] protected Button pvpButton, easyButton, mediumButton, hardButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		pvpButton.Pressed += OnPvpButtonPressed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void OnPvpButtonPressed()
	{
		EmitSignal(SignalName.PvpButtonPressed);
	}
}
