using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndLevelManager : MonoBehaviour
{

    public static int score;
    public static int level;
    public static int linesDestroyed;

    public Text scoreText;
    public Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        level = 1;
        linesDestroyed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = String.Format("{0:D8}", score);
        levelText.text = level.ToString();
    }
}
