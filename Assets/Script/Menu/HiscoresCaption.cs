using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script handler for hiscores captions
/// </summary>

public class HiscoresCaption : MonoBehaviour
{

    public Text[] scoresCaptions;
    public Text[] nameCaptions;
    public Text closeButtonCaption;
    public Text resetButtonCaption;

    // Modify captions
    public void ChangeCaptions()
    {
        switch(DataManagement.data.languageIndex)
        {
            case Language.English:
                resetButtonCaption.text = "Reset";
                closeButtonCaption.text = "Close";
                break;
            case Language.French:
                resetButtonCaption.text = "R.à.z";
                closeButtonCaption.text = "Fermer";
                break;
        }
    }

    // Display highscores
    public void DisplayHiscores()
    {
        switch (ScoreAndLevelManager.gameType)
        {
            case GameType.TetrisA:
                DisplayHiscoresFromTable(DataManagement.data.tetrisAHighscores);
                break;
            case GameType.TetrisB:
                DisplayHiscoresFromTable(DataManagement.data.tetrisBHighscores);
                break;
            default:
                break;
        }
    }

    public void DisplayHiscoresFromTable(List<KeyValuePair<uint, string>> table)
    {
        int i = 0;
        foreach (KeyValuePair<uint, string> hiscore in table)
        {
            scoresCaptions[i].text = hiscore.Key.ToString();
            nameCaptions[i].text = hiscore.Value;
            i++;
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
