using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script for the options menu
/// </summary>

public class OptionsMenu : MonoBehaviour
{
    private const string SceneName = "Options";

    // UI Elements
    public Slider musicSlider;
    public Slider soundSlider;
    public InputField userName;
    public Dropdown language;

    static readonly float maxValue = 10.0f;

    // Options caption
    public OptionsCaptions optionsCaptions;

    // On start: we get internal state to reflect the UI
    void Start()
    {
        musicSlider.value = maxValue * DataManagement.data.musicVolume;
        soundSlider.value = maxValue * DataManagement.data.soundVolume;
        userName.text = DataManagement.data.userName;
        language.value = (int)DataManagement.data.languageIndex;
    }

    // Change volume slider
    public void ChangeVolumeSlider()
    {
        DataManagement.data.musicVolume = musicSlider.value / maxValue;
    }

    // Change sound slider
    public void ChangeSoundSlider()
    {
        DataManagement.data.soundVolume = soundSlider.value / maxValue;
    }

    // Change username
    public void ChangeUsername()
    {
        DataManagement.data.userName = userName.text;
    }

    // Change language
    public void ChangeLanguage()
    {
        DataManagement.data.languageIndex = (Language)language.value;
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
