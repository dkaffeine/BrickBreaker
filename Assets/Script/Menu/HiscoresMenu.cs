using UnityEngine;

/// <summary>
/// Script ratteched to high scores menu
/// </summary>

public class HiscoresMenu : MonoBehaviour
{
    private const string SceneName = "Hiscores";

    public HiscoresCaption hiscoresCaption;

    // On start: update captions
    void Start()
    {
        hiscoresCaption.ChangeCaptions();
        hiscoresCaption.DisplayHiscores();
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
        ExtraScene.Unload(SceneName);
    }
}
