using UnityEngine;

/// <summary>
/// Script rattached to main menu
/// </summary>

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

    // Play is pressed: Enjoy!
    public void PlayClicked()
    {
        const string sceneName = "PlayInterface";
        ExtraScene.Load(sceneName);
    }

    // Opens options
    public void OptionsClicked()
    {
        const string sceneName = "Options";
        ExtraScene.Load(sceneName);
    }

    // Opens hiscores
    public void HiscoresAClicked()
    {
        const string sceneName = "HiscoresA";
        ExtraScene.Load(sceneName);
    }

    // Quit the application
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

    // Opens the help menu
    public void HelpClicked()
    {
        const string sceneName = "Help";
        ExtraScene.Load(sceneName);
    }

}
