using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiscoresCaption : MonoBehaviour
{

    public Text[] scoresCaptions;
    public Text[] nameCaptions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Display highscores
    public void DisplayHiscores()
    {
        int i = 0;
        foreach(KeyValuePair<uint, string> hiscore in DataManagement.data.hiscores)
        {
            scoresCaptions[i].text = hiscore.Key.ToString();
            nameCaptions[i].text = hiscore.Value;
            i++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
