using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCaptions : Captions
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void UpdateCaptions()
    {
        switch(DataManagement.data.languageIndex)
        {
            case 0:
                // English
                captions[0].text = "Play";
                captions[1].text = "Options";
                captions[2].text = "Hiscores";
                captions[3].text = "Quit";
                break;
            case 1:
                // French
                captions[0].text = "Jouer";
                captions[1].text = "Options";
                captions[2].text = "Hiscores";
                captions[3].text = "Quitter";
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
