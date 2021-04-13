using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script ratteched to high scores menu
/// </summary>

public class PlayInterfaceMenu : MonoBehaviour
{
    private const string SceneName = "PlayInterface";

    public PlayInterfaceCaption playInterfaceCaption;

    // On start: update captions
    void Start()
    {
        playInterfaceCaption.ChangeCaptions();
    }

    public void TetrisAClicked()
    {
        // Load game scene
        const string sceneName = "TetrisA";
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void TetrisBClicked()
    {
        // Load game scene
        const string sceneName = "TetrisB";
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    // Close this menu
    public void CloseMenu()
    {
        FileManagement.SaveData(DataManagement.data);
        ExtraScene.Unload(SceneName);
    }
}
