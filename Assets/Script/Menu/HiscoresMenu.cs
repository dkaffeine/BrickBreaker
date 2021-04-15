using System;
using UnityEngine;

/// <summary>
/// Script ratteched to high scores menu
/// </summary>

public class HiscoresMenu : MonoBehaviour
{
    private string sceneName;

    public GameType gameType;

    public HiscoresCaption hiscoresCaption;

    // On start: update captions
    void Start()
    {
        ScoreAndLevelManager.gameType = gameType;

        MakeSceneName();

        hiscoresCaption.ChangeCaptions();
        hiscoresCaption.DisplayHiscores();
    }

    private void MakeSceneName()
    {
        switch(gameType)
        {
            case GameType.TetrisA:
                sceneName = "HiscoresA";
                break;
            case GameType.TetrisB:
                sceneName = "HiscoresB";
                break;
            default:
                break;
        }
    }

    // Reset high scores
    public void ResetScores()
    {
        DataManagement.RegenerateHiscores();
        hiscoresCaption.DisplayHiscores();
    }

    // Close this menu
    public void CloseMenu()
    {
        FileManagement.SaveData(DataManagement.data);
        ExtraScene.Unload(sceneName);
    }
}
