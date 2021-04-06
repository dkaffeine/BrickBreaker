using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private const string SceneName = "Options";

    // UI Elements
    public Slider musicSlider;
    public Slider soundSlider;
    public InputField userName;
    public Dropdown language;

    // Options text
    public OptionsCaptions optionsCaptions;

    // Start is called before the first frame update
    void Start()
    {
        musicSlider.value = DataManagement.data.musicVolume;
        soundSlider.value = DataManagement.data.soundVolume;
        userName.text = DataManagement.data.userName;
        language.value = DataManagement.data.languageIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Change volume slider
    public void ChangeVolumeSlider()
    {
        DataManagement.data.musicVolume = musicSlider.value;
    }

    // Change sound slider
    public void ChangeSoundSlider()
    {
        DataManagement.data.soundVolume = soundSlider.value;
    }

    // Change username
    public void ChangeUsername()
    {
        DataManagement.data.userName = userName.text;
    }

    // Change language
    public void ChangeLanguage()
    {
        DataManagement.data.languageIndex = language.value;
        optionsCaptions.UpdateCaptions();

        // Update also captions in the scene loaded
        GameObject hud = GameObject.Find("UI");
        Captions captions = hud.GetComponent<DataManagement>().captions;
        captions.UpdateCaptions();
    }

    // Close menu
    public void CloseMenu()
    {
        FileManagement.SaveData(DataManagement.data);
        ExtraScene.Unload(SceneName);
    }

}
