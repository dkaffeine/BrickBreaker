/// <summary>
/// Main menu captions, derivated from Captions class
/// </summary>

public class MainMenuCaptions : Captions
{
    public override void UpdateCaptions()
    {
        switch(DataManagement.data.languageIndex)
        {
            case 0:
                // English
                captions[0].text = "Play";
                captions[1].text = "Options";
                captions[2].text = "Quit";
                break;
            case 1:
                // French
                captions[0].text = "Jouer";
                captions[1].text = "Options";
                captions[2].text = "Quitter";
                break;
        }
    }
}
