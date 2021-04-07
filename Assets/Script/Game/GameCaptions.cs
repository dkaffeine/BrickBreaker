using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCaptions : Captions
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void UpdateCaptions()
    {
        switch (DataManagement.data.languageIndex)
        {
            case 0:
                // English
                captions[0].text = "Main Menu";
                captions[1].text = "Restart";
                captions[2].text = "Options";
                captions[3].text = "Close";
                captions[4].text = "Game Over";
                captions[5].text = "Restart";
                captions[6].text = "Main Menu";
                captions[7].text = "Score";
                captions[8].text = "Level";
                captions[9].text = "Lines";
                break;
            case 1:
                // French
                captions[0].text = "Menu principal";
                captions[1].text = "Redémarrage";
                captions[2].text = "Options";
                captions[3].text = "Fermer";
                captions[4].text = "Fin de partie";
                captions[5].text = "Redémarrage";
                captions[6].text = "Menu principal";
                captions[7].text = "Score";
                captions[8].text = "Niveau";
                captions[9].text = "Lignes";
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
