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
    public Text closeButtonCaption;

    // Modify captions
    public void ChangeCaptions()
    {
        switch(DataManagement.data.languageIndex)
        {
            case 0:
                // English
                titleCaption.text = "Play";
                tetrisACaption.text = "Tetris A";
                tetrisBCaption.text = "Tetris B";
                closeButtonCaption.text = "Close";
                break;
            case 1:
                // French
                titleCaption.text = "Jouer";
                tetrisACaption.text = "Tetris A";
                tetrisBCaption.text = "Tetris B";
                closeButtonCaption.text = "Fermer";
                break;
        }
    }
}
