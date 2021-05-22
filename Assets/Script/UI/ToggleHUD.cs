using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Platform
{
    StandAlone,
    WebGL,
    Android
}

public class ToggleHUD: MonoBehaviour
{
    #region Fields
    #region Serialized fields
    [SerializeField] private GameObject _panel;
    [SerializeField] private Platform _platform;
    [Tooltip("Status on that platform, opposite status will be applied on other platforms")]
    [SerializeField] private bool _platformStatus;
    #endregion
    #endregion

    #region Methods
    #region Internal
    private void CheckPanel()
    {
        if (this._panel == null)
        {
            this._panel = this.gameObject;
        }
    }

    private void CheckPlatform()
    {
        switch(_platform)
        {
#if UNITY_ANDROID
            case Platform.Android:
                this._panel.SetActive(_platformStatus);
                break;
#endif
#if UNITY_STANDALONE
            case Platform.StandAlone:
                this._panel.SetActive(_platformStatus);
                break;
#endif
#if UNITY_WEBGL
            case Platform.WebGL:
                this._panel.SetActive(_platformStatus);
                break;
#endif
            default:
                this._panel.SetActive(_platformStatus == true ? false : true);
                break;
        }
    }

#endregion

#region Life Cycle
    private void OnEnable()
    {
        CheckPlatform();

        // Deactivate this script then
        this.enabled = false;
    }
#endregion
#endregion
}
