using Godot;
using System;

public partial class PlankoLevel : Node2D
{
    public int Score = 0;
    [Export]
    public Label ScoreValue;

    [Export]
    public Label RestartMessage;

    [Export]
    public PackedScene PlayerScene;

    [Export]
    public Node2D PlayerDisk;

    bool EnabledRestart = false;

    // Track how many balls are in the game and how many have scored
    private int ballsInGame = 0;
    private int ballsScored = 0;

    // The total number of balls to be spawned (3 balls)
    private const int MaxBalls = 3;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        RestartMessage.Hide();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        // Update the score display
        ScoreValue.Text = $"Score: {Score}";
        RestartMessage.Visible = EnabledRestart;

        // Restart the game if input is pressed and enabled
        if (Input.IsActionJustPressed("drop_disk") && EnabledRestart)
        {
            // Reset score and ball counts
            Score = 0;
            ballsInGame = 0;
            ballsScored = 0;
            ScoreValue.Text = $"Score: {Score}";

            // Spawn 3 new balls
            SpawnNewBalls();
            EnabledRestart = false;
            RestartMessage.Hide(); // Hide the restart message
        }
    }

    // Spawns 3 new players (balls)
    void SpawnNewBalls()
    {
        // Reset ball counters every time we spawn new balls
        ballsInGame = 0;
        ballsScored = 0;

        for (int i = 0; i < MaxBalls; i++)
        {
            RigidBody2D newPlayer = PlayerScene.Instantiate<RigidBody2D>();

            // Position the new ball at the top of the board
            newPlayer.Position = new Vector2(140, 25);
            PlayerDisk.AddChild(newPlayer);

            // Increment the number of balls in play
            ballsInGame++;
        }
    }

    public void IncreaseScore(int scoreIncrease)
    {
        Score += scoreIncrease;
        ballsScored++;

        if (ballsScored >= ballsInGame)
        {
            // Allow restart once all balls are scored
            EnabledRestart = true;
            RestartMessage.Text = "Left Click to RESTART";
            RestartMessage.Show();
        }
    }
}
