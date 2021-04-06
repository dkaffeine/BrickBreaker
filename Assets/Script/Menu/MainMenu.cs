using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public DataManagement dataManagement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClicked()
    {
        // Stop playing current background music
        dataManagement.backgroundMusic.Stop();

        // Load game scene
        const string sceneName = "Game";
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void OptionsClicked()
    {
        const string sceneName = "Options";
        ExtraScene.Load(sceneName);
    }

    public void HiscoresClicked()
    {
        const string sceneName = "Hiscores";
        ExtraScene.Load(sceneName);
    }

    public void QuitClicked()
    {

        // Save data
        FileManagement.SaveData(DataManagement.data);

        // Close application
#if UNITY_EDITOR
        // If we are in the editor: stopping playing the application ends it
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Otherwise: we quit the application
        Application.Quit();
#endif
    }

}
