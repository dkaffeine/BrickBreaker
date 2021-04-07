using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Pause panel script - the same panel is used for the Game Over
/// </summary>

public class PausePanel : MonoBehaviour
{

    // Handlers to game controller and data management
    public GameController gameController;
    public DataManagement dataManagement;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Go back to main menu
    public void MainMenuClicked()
    {
        // Stop playing current background music
        dataManagement.backgroundMusic.Stop();

        // Load game scene
        const string sceneName = "MainMenu";
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);

    }

    // Reloads the scene
    public void RestartClicked()
    {
        dataManagement.backgroundMusic.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    // Opens the options (used only in the pause menu)
    public void OptionsClicked()
    {
        const string sceneName = "Options";
        ExtraScene.Load(sceneName);
    }

    // Close this menu (used only in the pause menu)
    public void CloseClicked()
    {
        gameController.TogglePause();
    }
}
