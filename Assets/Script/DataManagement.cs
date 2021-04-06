using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManagement : MonoBehaviour
{

    public static DataToSave data;
    public static bool wereDataLoaded = false;
    public bool hasToResetData;

    // Background music
    public AudioSource backgroundMusic;

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

    // Generate hiscores
    public static void GenerateHiscores()
    {
        if (data.hiscoresGenerated == true)
        {
            // hiscores generated, return without doing anything
            return;
        }
        // Generate hiscores
        data.hiscoresGenerated = true;
        data.hiscores.Add(10000u, "10th place");
        data.hiscores.Add(20000u, "9th place");
        data.hiscores.Add(30000u, "8th place");
        data.hiscores.Add(40000u, "7th place");
        data.hiscores.Add(50000u, "6th place");
        data.hiscores.Add(60000u, "5th place");
        data.hiscores.Add(70000u, "4th place");
        data.hiscores.Add(80000u, "3rd place");
        data.hiscores.Add(90000u, "2nd place");
        data.hiscores.Add(100000u, "1st place");
    }

    // Regenerate highscores
    public static void RegenerateHiscores()
    {
        // Clear old hiscores
        data.hiscores.Clear();
        data.hiscoresGenerated = false;

        // And generate them again
        GenerateHiscores();
    }

    public static void AddHiscore(uint score)
    {
        // We add an hiscore to the list
        data.hiscores.Add(score, data.userName);

        // We keep the top 10 then, since there are 11 values, the first one is the lowest score
        data.hiscores.Remove(data.hiscores.Keys.First());
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
    }
}