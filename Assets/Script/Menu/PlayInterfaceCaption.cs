using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script handler for hiscores captions
/// </summary>

public class PlayInterfaceCaption : MonoBehaviour
{

    public Text titleCaption;
    public Text tetrisACaption;
    public Text tetrisBCaption;
    public Text highscoresACaption;
    public Text highscoresBCaption;
    public Text closeButtonCaption;

    // Modify captions
    public void ChangeCaptions()
    {
        switch(DataManagement.data.languageIndex)
        {
            case Language.English:
                titleCaption.text = "Play";
                tetrisACaption.text = "Tetris A";
                tetrisBCaption.text = "Tetris B";
                highscoresACaption.text = "High Scores";
                highscoresBCaption.text = "High Scores";
                closeButtonCaption.text = "Close";
                break;
            case Language.French:
                titleCaption.text = "Jouer";
                tetrisACaption.text = "Tetris A";
                tetrisBCaption.text = "Tetris B";
                highscoresACaption.text = "Classement";
                highscoresBCaption.text = "Classement";
                closeButtonCaption.text = "Fermer";
                break;
        }
    }
}
