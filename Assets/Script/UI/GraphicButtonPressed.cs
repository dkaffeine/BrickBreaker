using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Class that simulates both pressing button and keeping button pressed
/// </summary>

public class GraphicButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    // UI Button status
    #region Fields

    #region Internal
    private bool _buttonPressed = false;

    #endregion Internal

    #region Accessors

    public bool ButtonPressed
    {
        get { return _buttonPressed; }
    }

    #endregion Accessors

    #endregion Fields

    #region Methods

    #region CallBacks

    public void OnPointerDown(PointerEventData eventData)
    {
        _buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _buttonPressed = false;
    }

    #endregion CallBacks

    #endregion Methods
}
