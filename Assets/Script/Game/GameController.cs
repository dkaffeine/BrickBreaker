using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public bool isPaused = false;
    public GameObject pausePanel;

    public ButtonPressed buttonPressedLeft;
    public ButtonPressed buttonPressedRight;
    public ButtonPressed buttonPressedDown;
    public ButtonPressed buttonPressedH;
    public ButtonPressed buttonPressedJ;

    // Determines when the key was pressed last
    public float lastKeyDown;
    public float lastPressedTime;

    // Determine time between two repetitions
    private float deltaTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Toggle Pause
    public void TogglePause()
    {
        Time.timeScale = Time.timeScale > 0.0f ? 0.0f : 1.0f;
        pausePanel.SetActive(!pausePanel.activeSelf);
        isPaused = !isPaused;
    }

    // Get
    public bool GetKeyPressed(KeyCode keyCode, ButtonPressed buttonPressed)
    {
        bool isKeyDown = Input.GetKeyDown(keyCode) || buttonPressed.HasThisButtonBeenJustPushed();
        bool isPressed = Input.GetKey(keyCode) || buttonPressed.IsPressed();

        if (isKeyDown)
        {
            // Last time button was pressed is the current time
            lastKeyDown = Time.time;
            lastPressedTime = Time.time;
        }
        if (isPressed && Time.time >= lastPressedTime + deltaTime)
        {
            // Last time button is pressed
            lastPressedTime = Time.time;
            isKeyDown = true;
        }

        return isKeyDown;
    }

    // Get the different keys
    public bool GetHPressed()
    {
        return GetKeyPressed(KeyCode.H, buttonPressedH);
    }
    public bool GetJPressed()
    {
        return GetKeyPressed(KeyCode.J, buttonPressedJ);
    }
    public bool GetDownPressed()
    {
        return GetKeyPressed(KeyCode.DownArrow, buttonPressedDown);
    }
    public bool GetLeftPressed()
    {
        return GetKeyPressed(KeyCode.LeftArrow, buttonPressedLeft);
    }
    public bool GetRightPressed()
    {
        return GetKeyPressed(KeyCode.RightArrow, buttonPressedRight);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
}
