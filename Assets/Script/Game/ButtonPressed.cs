using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool isPressed;
    private bool wasPressed;
    private bool hasThisButtonBeenJustPushed;

    // Start is called before the first frame update
    void Start()
    {
        // On start, the button is not pressed
        isPressed = false;
        wasPressed = false;
        hasThisButtonBeenJustPushed = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        isPressed = true;
    }

    // Method from interface IPointerUpHandler called when you releast the press on the button
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
