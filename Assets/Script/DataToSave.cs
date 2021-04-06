
using System.Collections.Generic;
/// <summary>
/// Serializable class used to save options data
/// </summary>
[System.Serializable]
public class DataToSave
{
    public float musicVolume = 0.5f;
    public float soundVolume = 0.0f;

    // Name
    public string userName = "Player";

    // Language
    public int languageIndex = 1;

    // Hiscores
    public bool hiscoresGenerated = false;
    public List<KeyValuePair<uint, string>> hiscores = new List<KeyValuePair<uint, string>>();

}
