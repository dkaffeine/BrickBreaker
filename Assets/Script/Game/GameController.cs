using UnityEngine;

/// <summary>
/// Game controller - retrieve both information about the keyboard pressed and the buttons on Android HUD pressed
/// </summary>

public class GameController : MonoBehaviour
{

    public bool isPaused = false;
    public GameObject pausePanel;

    [SerializeField] private ControllerButton buttonPressedLeft;
    [SerializeField] private ControllerButton buttonPressedRight;
    [SerializeField] private ControllerButton buttonPressedDown;
    [SerializeField] private ControllerButton buttonPressedH;
    [SerializeField] private ControllerButton buttonPressedJ;
    [SerializeField] private ControllerButton buttonPressedSpace;

    // Determines when the key was pressed last
    private float lastKeyDown;
    private float lastPressedTime;

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
    public bool GetKeyPressed(ControllerButton buttonPressed)
    {
        bool isKeyDown = buttonPressed.JustPressed;
        bool isPressed = buttonPressed.IsPressed;

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
        return GetKeyPressed(buttonPressedH);
    }
    public bool GetJPressed()
    {
        return GetKeyPressed(buttonPressedJ);
    }
    public bool GetDownPressed()
    {
        return GetKeyPressed(buttonPressedDown);
    }
    public bool GetLeftPressed()
    {
        return GetKeyPressed(buttonPressedLeft);
    }
    public bool GetRightPressed()
    {
        return GetKeyPressed(buttonPressedRight);
    }
    public bool GetSpacePressed()
    {
        return GetKeyPressed(buttonPressedSpace);
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
