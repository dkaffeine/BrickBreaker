using UnityEngine;

/// <summary>
/// Grid that is used upon all elements
/// 
/// Implements all transformations that will be used when a row has to be deleted
/// </summary>

public class GameEngineGrid : MonoBehaviour
{
    // Grid size
    public static int height = 20;
    public static int width = 10;

    // Grid storing all Transform elements
    public static Transform[,] grid = new Transform[width, height];

    // Convert a float position to the closest integer position
    public static Vector2 ClosestGridPosition(Vector2 position)
    {
        return new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
    }

    // Check if the given vector is inside the game grid
    public static bool InsideGrid(Vector2 position)
    {
        return (int)position.x >= 0 && (int)position.x < width && (int)position.y >= 0;
    }

    // Destroy the row at the given height
    public static void DeleteRow(int rowToDelete)
    {
        for (int x = 0; x < width; x++)
        {
            Destroy(grid[x, rowToDelete].gameObject);
            grid[x, rowToDelete] = null;
        }
    }

    // Make a row falling to the line below
    public static void DecreaseRow(int rowPosition)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, rowPosition] != null)
            {
                // Move the block towards the row below in the game engine
                grid[x, rowPosition - 1] = grid[x, rowPosition];
                grid[x, rowPosition] = null;

                // Move the block towards the row below in the graphical engine
                grid[x, rowPosition - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    // When we delete a row, we should make all row about it falling by one
    public static void DecreaseAllRowsAbove(int rowPosition)
    {
        for (int y = rowPosition + 1; y < height; y++)
        {
            DecreaseRow(y);
        }
    }

    // Check if a row is full, then we can delete it
    public static bool IsRowFull(int rowToCheck)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, rowToCheck] == null)
            {
                return false;
            }
        }
        return true;
    }

    public static void CheckGridAndScore()
    {
        int linesDestroyed = 0;

        // We check from top to bottom to avoid unnecessarily loopins in case of row deletion
        for (int rowToCheck = height-1; rowToCheck >= 0; rowToCheck--)
        {
            if (IsRowFull(rowToCheck))
            {
                // If a row is full, we delete it and move down all rows above
                DeleteRow(rowToCheck);
                DecreaseAllRowsAbove(rowToCheck);
                linesDestroyed++;
            }
        }

        // Update lines
        ScoreAndLevelManager.linesDestroyed += linesDestroyed;
        AudioSource audioSource;

        // Update score
        switch(linesDestroyed)
        {
            case 0:
                break;
            case 1:
                ScoreAndLevelManager.score += (uint)ScoreAndLevelManager.level * 100;
                audioSource = GameObject.Find("UI").GetComponent<DataManagement>().soundEffects[0];
                audioSource.Play();
                break;
            case 2:
                ScoreAndLevelManager.score += (uint)ScoreAndLevelManager.level * 300;
                audioSource = GameObject.Find("UI").GetComponent<DataManagement>().soundEffects[1];
                audioSource.Play();
                break;
            case 3:
                ScoreAndLevelManager.score += (uint)ScoreAndLevelManager.level * 600;
                audioSource = GameObject.Find("UI").GetComponent<DataManagement>().soundEffects[2];
                audioSource.Play();
                break;
            case 4:
                ScoreAndLevelManager.score += (uint)ScoreAndLevelManager.level * 1000;
                audioSource = GameObject.Find("UI").GetComponent<DataManagement>().soundEffects[3];
                audioSource.Play();
                break;
        }

        // Update level
        ScoreAndLevelManager.level = ScoreAndLevelManager.linesDestroyed / 10;
    }

}

