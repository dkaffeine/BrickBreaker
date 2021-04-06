using UnityEngine;

public class Piece : MonoBehaviour
{
    private ButtonPressed buttonPressedLeft;
    private ButtonPressed buttonPressedRight;
    private ButtonPressed buttonPressedDown;
    private ButtonPressed buttonPressedUp;

    // Start is called before the first frame update
    void Start()
    {
        if (CheckIfAndroidHUD() == true)
        {
            buttonPressedDown = GameObject.Find("ButtonDown").GetComponent<ButtonPressed>();
            buttonPressedUp = GameObject.Find("ButtonUp").GetComponent<ButtonPressed>();
            buttonPressedLeft = GameObject.Find("ButtonLeft").GetComponent<ButtonPressed>();
            buttonPressedRight = GameObject.Find("ButtonRight").GetComponent<ButtonPressed>();
        }
    }

    public bool CheckIfAndroidHUD()
    {
        GameObject androidHUD = GameObject.Find("Android HUD");
        return (androidHUD != null);
    }

    // Game over
    void GameOver()
    {
        enabled = false;
        GameObject.Find("GameOverPanel").SetActive(true);
        DataManagement.AddHiscore(ScoreAndLevelManager.score);
        FileManagement.SaveData(DataManagement.data);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
