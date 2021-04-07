using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script handler for options captions
/// </summary>

public class OptionsCaptions : MonoBehaviour
{

    public Text musicCaption;
    public Text soundCaption;
    public Text usernameCaption;
    public Text languageCaption;
    public Text closeButtonCaption;

    // On start: update captions
    void Start()
    {
        UpdateCaptions();
    }

    // Update captions
    public void UpdateCaptions()
    {
        switch(DataManagement.data.languageIndex)
        {
            case 0:
                // English
                musicCaption.text = "Music";
                soundCaption.text = "Effects";
                usernameCaption.text = "Username";
                languageCaption.text = "Language";
                closeButtonCaption.text = "Close";
                break;
            case 1:
                // French
                musicCaption.text = "Musique";
                soundCaption.text = "Effets";
                usernameCaption.text = "Utilisateur";
                languageCaption.text = "Langue";
                closeButtonCaption.text = "Fermer";
                break;
        }
    }
}
