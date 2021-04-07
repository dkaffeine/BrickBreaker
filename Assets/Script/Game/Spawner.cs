using UnityEngine;

/// <summary>
/// Pieces spawner
/// </summary>

public class Spawner : MonoBehaviour
{

    // List of pieces
    public GameObject[] pieces;

    // Reference to the game over script
    public GameObject gameOver;

    // Next piece Id
    public int nextId;

    // On start: we generate a random piece
    void Start()
    {
        nextId = Random.Range(0, pieces.Length);
        SpawnNextPiece();
    }

    // Spawn next piece
    public void SpawnNextPiece()
    {
        // Spawn piece at current position
        CreatePiece(transform.position);

        // Defines next Id
        nextId = Random.Range(0, pieces.Length);
    }

    // Create a piece in the game engine
    public GameObject CreatePiece(Vector3 piecePosition)
    {
        GameObject piece = Instantiate(pieces[nextId], piecePosition, Quaternion.identity);
        return piece;
    }
}
