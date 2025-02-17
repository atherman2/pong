using Godot;
using System;

public partial class Game : Node2D
{
	[Export] private Score score;
	[Export] private Ball ball;
	private int playerScore, opponentScore = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ball.Scored += OnScored;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnScored(ScoreBoundary.ScoreSideObject scoreSideObject)
	{
		ScoreBoundary.ScoreSide scoreSide = scoreSideObject.GetScoreSide();
		switch(scoreSide)
		{
			case ScoreBoundary.ScoreSide.PLAYER:

				score.SetPlayerScoreText(++playerScore);
				break;

			case ScoreBoundary.ScoreSide.OPPONENT:

				score.SetOpponentScoreText(++opponentScore);
				break;
		}
	}
}
