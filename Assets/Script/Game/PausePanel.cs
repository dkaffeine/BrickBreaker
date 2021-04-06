using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{

    public GameController gameController;
    public DataManagement dataManagement;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenuClicked()
    {
        // Stop playing current background music
        dataManagement.backgroundMusic.Stop();

        // Load game scene
        const string sceneName = "MainMenu";
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);

    }

    public void RestartClicked()
    {
        dataManagement.backgroundMusic.Stop();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void OptionsClicked()
    {
        const string sceneName = "Options";
        ExtraScene.Load(sceneName);
    }

    public void CloseClicked()
    {
        gameController.TogglePause();
    }
}
