using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that deals with data management, take track of music / sounds and captions
/// </summary>

public class DataManagement : MonoBehaviour
{

    // Data handlers
    public static DataToSave data;
    public static bool wereDataLoaded = false;
    // Do we need to reset data (used when we had to)?
    public bool hasToResetData;

    // Background music
    public AudioSource backgroundMusic;

    // Sound effects
    public bool hasSoundEffects;
    public AudioSource[] soundEffects;

    // Captions
    public Captions captions;

    // Start is called before the first frame update
    void Start()
    {
        LoadData();

        PlayBackgroundMusic();

        captions.UpdateCaptions();
    }

    // Load data from disk, save data first
    public void LoadData()
    {
        if (wereDataLoaded == false)
        {
            if (hasToResetData == true)
            {
                data = new DataToSave();
                FileManagement.SaveData(data);
            }
            else
            {
                data = FileManagement.LoadData();
            }
            GenerateHiscores();
            wereDataLoaded = true;
        }
    }

    /// <summary>
    /// Generates highscores for a single game
    /// </summary>
    /// <param name="flag">Information on highscores generation needed</param>
    /// <param name="highscoresData">Data handle to generate</param>
    public static void GenerateHiscoresSingleGame(ref bool flag, ref List<KeyValuePair<uint, string>> highscoresData)
    {
        if (flag == true)
        {
            // Highscores generated for that game, do nothing
            return;
        }

        flag = true;
        highscoresData = new List<KeyValuePair<uint, string>>();
        highscoresData.Add(new KeyValuePair<uint, string>(5000u, "10th place"));
        highscoresData.Add(new KeyValuePair<uint, string>(10000u, "9th place"));
        highscoresData.Add(new KeyValuePair<uint, string>(15000u, "8th place"));
        highscoresData.Add(new KeyValuePair<uint, string>(20000u, "7th place"));
        highscoresData.Add(new KeyValuePair<uint, string>(25000u, "6th place"));
        highscoresData.Add(new KeyValuePair<uint, string>(30000u, "5th place"));
        highscoresData.Add(new KeyValuePair<uint, string>(35000u, "4th place"));
        highscoresData.Add(new KeyValuePair<uint, string>(40000u, "3rd place"));
        highscoresData.Add(new KeyValuePair<uint, string>(45000u, "2nd place"));
        highscoresData.Add(new KeyValuePair<uint, string>(50000u, "1st place"));
    }

    // Generate hiscores
    public static void GenerateHiscores()
    {
        // Generates for the Tetris A game
        GenerateHiscoresSingleGame(ref data.tetrisAHighscoresGenerated, ref data.tetrisAHighscores);

        // Generates for the Tetris B game
        GenerateHiscoresSingleGame(ref data.tetrisBHighscoresGenerated, ref data.tetrisBHighscores);
    }

    // Regenerate highscores
    public static void RegenerateHiscores()
    {
        // Clear old hiscores
        data.tetrisAHighscores.Clear();
        data.tetrisAHighscoresGenerated = false;

        // And generate them again
        GenerateHiscores();
    }

    public static void AddHiscore(uint score)
    {
        // We add an hiscore to the list
        data.tetrisAHighscores.Add(new KeyValuePair<uint, string>(score, data.userName));

        // Sort list
        data.tetrisAHighscores.Sort((x, y) => x.Key.CompareTo(y.Key));

        // We keep the top 10 then, since there are 11 values, the first one is the lowest score
        data.tetrisAHighscores.RemoveAt(0);
    }

    public void PlayBackgroundMusic()
    {
        backgroundMusic.volume = data.musicVolume;
        backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // On update: set the background volume to the music volume
        backgroundMusic.volume = data.musicVolume;

        // On update: set the sound effects to the effects volume
        if (hasSoundEffects == true)
        { 
            foreach(AudioSource se in soundEffects)
            {
                se.volume = data.soundVolume;
            }
        }
    }
}
