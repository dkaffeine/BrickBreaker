using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] pieces;

    // Next piece Id
    public int nextId;

    // Start is called before the first frame update
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
        nextId = Random.Range(0, pieces .Length);
    }

    // Create a piece
    public GameObject CreatePiece(Vector3 piecePosition)
    {
        GameObject piece = Instantiate(pieces[nextId], piecePosition, Quaternion.identity);
        return piece;
    }
}
