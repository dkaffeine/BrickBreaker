using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{

    private const string SceneName = "Help";

    public HelpCaptions helpCaptions;

    // Start is called before the first frame update
    void Start()
    {
        helpCaptions.ChangeCaptions();
    }

    public void CloseMenu()
    {
        ExtraScene.Unload(SceneName);
    }
}
