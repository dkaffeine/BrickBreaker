/// <summary>
/// Game captions, derivated from Captions class
/// </summary>

public class GameCaptions : Captions
{
    public override void UpdateCaptions()
    {
        switch (DataManagement.data.languageIndex)
        {
            case Language.English:
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
                captions[10].text = "Next";
                break;
            case Language.French:
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
                captions[10].text = "Prochain";
                break;
        }
    }
}
