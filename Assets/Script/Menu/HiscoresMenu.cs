using UnityEngine;

public class HiscoresMenu : MonoBehaviour
{
    private const string SceneName = "Hiscores";

    public HiscoresCaption hiscoresCaption;

    // Start is called before the first frame update
    void Start()
    {
        hiscoresCaption.ChangeCaptions();
        hiscoresCaption.DisplayHiscores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScores()
    {
        DataManagement.RegenerateHiscores();
        hiscoresCaption.DisplayHiscores();
    }

    public void CloseMenu()
    {
        FileManagement.SaveData(DataManagement.data);
        ExtraScene.Unload(SceneName);
    }
}
