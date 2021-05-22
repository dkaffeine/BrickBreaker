using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Class that simulates both pressing button and keeping button pressed
/// </summary>

public class GraphicButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    // UI Button status
    private bool isUIButtonPressed = false;

    // Button status
    private bool isPressed = false;
    private bool wasPressed = false;
    private bool hasThisButtonBeenJustPushed = false;

    // Equivalent keyboard code
    public KeyCode keyCode;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        // Set up the press status
        isPressed = isUIButtonPressed || Input.GetKey(keyCode);

        // The button has been just pressed if it was not pressed before but just now
        hasThisButtonBeenJustPushed = (wasPressed == false && isPressed == true) ? true : false;

        // Update internal state
        wasPressed = isPressed;
    }

    // Method that returns if the button is pressed
    public bool IsPressed()
    {
        return isPressed;
    }

    // Method that returns if the button has been just pushed
    public bool HasThisButtonBeenJustPushed()
    {
        return hasThisButtonBeenJustPushed;
    }

    // Method from interface IPointerDownHandler called when you press down the button
    public void OnPointerDown(PointerEventData eventData)
    {
        isUIButtonPressed = true;
    }

    // Method from interface IPointerUpHandler called when you releast the press on the button
    public void OnPointerUp(PointerEventData eventData)
    {
        isUIButtonPressed = false;
    }
}
