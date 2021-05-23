using UnityEngine;

public class ControllerButton : MonoBehaviour
{

    #region Fields

    #region Serialized
    [SerializeField] private GraphicButtonPressed _graphicButton;
    [SerializeField] private KeyCode _keyboardButton;
    #endregion Serialized

    #region Internal
    private bool _isPressed = false;
    private bool _wasPressed = false;
    private bool _hasThisButtonBeenJustPushed = false;
    #endregion

    #region Accessors

    public GraphicButtonPressed GraphicButton
    {
        get { return _graphicButton; }
    }

    public KeyCode KeyboardButton
    {
        get { return _keyboardButton; }
    }

    public bool IsPressed
    {
        get { return _isPressed; }
    }

    public bool JustPressed
    {
        get { return _hasThisButtonBeenJustPushed; }
    }
    #endregion Accessors

    #endregion Fields

    #region Methods

    #region Life Cycle

    void Update()
    {
        // Set the press status to
        _isPressed = GraphicButton.ButtonPressed || Input.GetKey(_keyboardButton);

        // Set the has the button been just pressed status
        _hasThisButtonBeenJustPushed = _wasPressed == false && _isPressed == true ? true : false;

        // Updates the internal pressed status
        _wasPressed = _isPressed;
    }

    #endregion Life Cycle

    #endregion Methods
}
