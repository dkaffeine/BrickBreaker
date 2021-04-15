using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handler for score, level and lines destroyed tracking
/// </summary>

public class ScoreAndLevelManager : MonoBehaviour
{

    public static GameType gameType = GameType.TetrisA;
    public static uint score;
    public static uint level;
    public static uint linesDestroyed;

    public Text scoreText;
    public Text levelText;
    public Text linesDestroyedText;

    // On start: we refresh the game
    void Start()
    {
        score = 0;
        level = 1;
        linesDestroyed = 0;
    }

    void Update()
    {
        UpdateScoreLevelAndLines();
    }

    // Update of score, level and lines
    void UpdateScoreLevelAndLines()
    {
        scoreText.text = String.Format("{0:D8}", score);
        levelText.text = level.ToString();
        linesDestroyedText.text = linesDestroyed.ToString();
    }
}
