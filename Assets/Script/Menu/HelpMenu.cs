using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{

    private const string SceneName = "Help";

    public HelpCaptions helpCaptions;

    // On start: update captions
    void Start()
    {
        helpCaptions.ChangeCaptions();
    }

    // Close this menu
    public void CloseMenu()
    {
        ExtraScene.Unload(SceneName);
    }
}
