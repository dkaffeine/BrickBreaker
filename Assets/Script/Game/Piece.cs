using UnityEngine;

public class Piece : MonoBehaviour
{

    // Time since last fall iteration
    private float lastFallTime;

    // Reference to game controller
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        // Set the last fall time on the grid
        lastFallTime = Time.time;
    }

    // Check if the position of the piece fits to a valid grid position
    bool IsValidGridPosition()
    {
        foreach(Transform child in transform)
        {
            Vector2 childPosition = GameEngineGrid.ClosestGridPosition(child.position);

            // If the piece is going of the grid, it's not a valid position
            if (!GameEngineGrid.InsideGrid(childPosition))
            {
                return false;
            }

            // Since all elements of the piece would fit inside the grid, let us
            // check if they don't collide with another element already there
            if (GameEngineGrid.grid[(int)childPosition.x, (int)childPosition.y] != null &&
                GameEngineGrid.grid[(int)childPosition.x, (int)childPosition.y].parent != transform)
            {
                return false;
            }
        }

        // If all tests passed, return true
        return true;
    }

    // Update the grid
    void UpdateGrid()
    {
        for (int y=0; y < GameEngineGrid.height; y++)
        {
            for (int x = 0; x < GameEngineGrid.width; x++)
            {
                // Destroy the element of the grid if the parent of the element placed is the current transform
                if (GameEngineGrid.grid[x, y] != null && GameEngineGrid.grid[x, y].parent == transform)
                {
                    GameEngineGrid.grid[x, y] = null;
                }
            }
        }

        // Set each child inside the grid
        foreach(Transform child in transform)
        {
            Vector2 childPosition = GameEngineGrid.ClosestGridPosition(child.position);
            GameEngineGrid.grid[(int)childPosition.x, (int)childPosition.y] = child;
        }
    }

    // Try changing position
    void TryChangePosition(Vector3 displacement)
    {

        // Move the object with respect to displacement
        transform.position += displacement;

        // Check if the movement is a valid one
        if (IsValidGridPosition())
        {
            // If it's a valid grid position, update it
            UpdateGrid();
        }
        else
        {
            // Revert displacement
            transform.position -= displacement;
        }

    }

    // Try changing rotation
    void TryRotatePiece(Vector3 angle)
    {

        if (gameObject.tag == "Cube")
        {
            // Don't rotate cube-shaped objects
            return;
        }

        // Rotate the object
        transform.Rotate(angle);

        // Check if the movement is a valid one
        if (IsValidGridPosition())
        {
            // If it's a valid grid position, update it
            UpdateGrid();
        }
        else
        {
            // Revert displacement
            transform.Rotate(new Vector3(-angle.x, -angle.y, -angle.z));
        }

    }


    // Make that piece falling
    void PieceFalling()
    {
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

        if (gameController.isPaused)
        {
            // If the game is on pause, do nothing
            return;
        }


        if (gameController.GetLeftPressed())
        {
            // Move left if it does not collide anything
            TryChangePosition(new Vector3(-1, 0, 0));
        }

        if (gameController.GetRightPressed())
        {
            // Move left if it does not collide anything
            TryChangePosition(new Vector3(1, 0, 0));
        }

        if (gameController.GetHPressed())
        {
            // Rotate counter-clockwise when H is pressed
            TryRotatePiece(new Vector3(0, 0, -90));
        }

        if (gameController.GetJPressed())
        {
            // Rotate counter-clockwise when J is pressed
            TryRotatePiece(new Vector3(0, 0, 90));
        }
    }

}
