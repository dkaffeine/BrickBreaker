using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSpawner : MonoBehaviour
{

    // Reference to the current spawner
    public Spawner spawner;

    // Current piece, 
    private GameObject currentPieceObject;
    private int currentPieceId;

    // Create a fixed piece at the current spawner position
    void CreateFixedPiece()
    {
        // Put the information of the next piece as the current piece for the next spawner
        currentPieceObject = spawner.CreatePiece(transform.position);
        currentPieceId = spawner.nextId;

        Piece piece = (Piece)currentPieceObject.GetComponent(typeof(Piece));
        piece.enabled = false;
    }

    // Delete the current piece inside the next spawner
    void DeleteFixedPiece()
    {
        Destroy(currentPieceObject);
    }

// Start is called before the first frame update
    void Start()
    {
        CreateFixedPiece();        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPieceId != spawner.nextId)
        {
            // We update the piece in the next spawner if the next piece's id is effectively different
            DeleteFixedPiece();
            CreateFixedPiece();
        }
    }
}
