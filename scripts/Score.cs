using Godot;
using System;

public partial class Score : Control
{
	[Export] private Label playerScoreLabel, opponentScoreLabel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SetPlayerScoreText(int score)
	{
		playerScoreLabel.Text = $"{score}";
	}

	public void SetOpponentScoreText(int score)
	{
		opponentScoreLabel.Text = $"{score}";
	}
}
