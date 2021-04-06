using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        // On start, the button is not pressed
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Method that returns if the button is pressed
    public bool IsPressed()
    {
        return isPressed;
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
