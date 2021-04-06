using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsCaptions : MonoBehaviour
{

    public Text musicCaption;
    public Text soundCaption;
    public Text usernameCaption;
    public Text languageCaption;
    public Text closeButtonCaption;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCaptions();
    }

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


    // Update is called once per frame
    void Update()
    {
        
    }
}
