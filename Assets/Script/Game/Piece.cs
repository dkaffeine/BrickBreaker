using UnityEngine;

/// <summary>
/// Script attached to the spawned piece and handles the game engine part for the piece
/// 
/// Note that once the piece reached the ground, script is disabled, so that only one piece is moving at a time
/// </summary>

public class Piece : MonoBehaviour
{
    #region Fields

    #region Serialized

    // Reference to the grid

    // Reference to game controller to get control keys
    [SerializeField] private GameController gameController;

    // Reference to data management to get sound effects
    [SerializeField] private DataManagement dataManagement;

    // Reference to the block collection transform object
    [SerializeField] private Transform blockCollection;

    #endregion Serialized

    #region Internal

    #endregion Internal

    #endregion Fields


    // Time since last fall iteration
    private float lastFallTime;

    // Delta time for falling at level 1
    private readonly float fallTimeStartingLevel = 1.5f;


    // Reference to the spawner to get the game over panel
    private Spawner spawner;

    private void Awake()
    {
        // Get references from different objets in scene
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        dataManagement = GameObject.Find("GameController").GetComponent<DataManagement>();
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        blockCollection = GameObject.Find("BlockCollection").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set the last fall time on the grid
        lastFallTime = Time.time;

        // Check if the starting position is a valid position
        CheckInitialGridPosition();
    }

    // Check if initial position is valid
    void CheckInitialGridPosition()
    {
        if (IsValidGridPosition())
        {
            // If the position is valid, we insert it inside the grid
            InsertChildrenInGrid();
        }
        else
        {
            // If you cannot place the piece on start, this is the game over
            GameOver();
        }

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

    // Initial insert 
    void InsertChildrenInGrid()
    {

        // Set each child inside the grid
        foreach (Transform child in transform)
        {
            Vector2 childPosition = GameEngineGrid.ClosestGridPosition(child.position);
            GameEngineGrid.grid[(int)childPosition.x, (int)childPosition.y] = child;
        }
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

        InsertChildrenInGrid();
    }

    // Try changing position
    bool TryChangePosition(Vector3 displacement)
    {

        // Move the object with respect to displacement
        transform.position += displacement;

        // Check if the movement is a valid one
        if (IsValidGridPosition())
        {
            // If it's a valid grid position, update it and play sound
            AudioSource audioSource = dataManagement.soundEffects[4];
            audioSource.Play();
            UpdateGrid();
            return true;
        }
        else
        {
            // Revert displacement
            transform.position -= displacement;
            return false;
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
            // If it's a valid grid position, update it and play sound
            AudioSource audioSource = dataManagement.soundEffects[4];
            audioSource.Play();

            // Backward rotates each child, so that all blocks composing 
            foreach (Transform child in transform)
            {
                child.Rotate(-angle);
            }

            UpdateGrid();
        }
        else
        {
            // Revert displacement
            transform.Rotate(-angle);
        }

    }


    // Make that piece falling
    void PieceFalling()
    {

        if (TryChangePosition(new Vector3(0, -1, 0)) == false)
        {
            // Piece was falling, update sound
            AudioSource audioSource = dataManagement.soundEffects[6];
            audioSource.Play();

            // Trigger grid line deletion (if any) and score
            GameEngineGrid.CheckGridAndScore();

            // Spawn the next piece
            spawner.SpawnNextPiece();

            // Deactivate this piece
            DeactivatePiece();
        }
    }

    // Deactivate the piece
    internal void DeactivatePiece()
    {
        int childCount = transform.childCount;
        for (int i = childCount-1; i >=0; i--)
        {
            transform.GetChild(i).SetParent(blockCollection);
        }

        // Destroy game object
        Destroy(gameObject);
    }

    // Make the piece falling until it reaches the ground
    void PieceFallingToTheGround()
    {

        uint scoreFalling = 0;

        while (TryChangePosition(new Vector3(0, -1, 0)) == true)
        {
            scoreFalling += ScoreAndLevelManager.level * 5;
        }

        ScoreAndLevelManager.score += scoreFalling;

        PieceFalling();
    }

    // Game over
    void GameOver()
    {
        enabled = false;
        DisableAndroidHUD();
        spawner.gameOver.SetActive(true);
        DataManagement.AddHiscore(ScoreAndLevelManager.score);
        FileManagement.SaveData(DataManagement.data);
    }

    // Disable Android HUD
    void DisableAndroidHUD()
    {
        GameObject androidHud = GameObject.Find("Android HUD");
        if (androidHud != null)
        {
            androidHud.SetActive(false);
        }
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
            TryRotatePiece(new Vector3(0, 0, 90));
        }

        if (gameController.GetJPressed())
        {
            // Rotate counter-clockwise when J is pressed
            TryRotatePiece(new Vector3(0, 0, -90));
        }

        if (gameController.GetDownPressed() || Time.time - lastFallTime >= fallTimeStartingLevel / Mathf.Sqrt(ScoreAndLevelManager.level))
        {
            PieceFalling();
            lastFallTime = Time.time;
        }

        if (gameController.GetSpacePressed())
        {
            PieceFallingToTheGround();
        }
    }
}
