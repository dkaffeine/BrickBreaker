using System.Collections.Generic;

/// <summary>
/// Serializable class used to save options data
/// </summary>

public enum Language
{
    English = 0,
    French = 1
}

[System.Serializable]
public class DataToSave
{
    public float musicVolume = 0.8f;
    public float soundVolume = 0.8f;

    // Name
    public string userName = "Player";

    // Language index - 0 stands for English, 1 stands for French
    public Language languageIndex = Language.French;

    // Tetris A Hiscores
    public bool tetrisAHighscoresGenerated = false;
    public List<KeyValuePair<uint, string>> tetrisAHighscores = new List<KeyValuePair<uint, string>>();

    // Tetris B Hiscores
    public bool tetrisBHighscoresGenerated = false;
    public List<KeyValuePair<uint, string>> tetrisBHighscores = new List<KeyValuePair<uint, string>>();
}
