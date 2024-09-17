using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
     private MazeGenerator mazeGenerator;
    [SerializeField] private Vector2 dungeonSize;  // Tamaño del laberinto
    [SerializeField] private int startPos;         // Posición inicial

    
    
    void Start()
    {
       mazeGenerator = new MazeGenerator(dungeonSize, startPos);
        List<Cell> generatedMaze = mazeGenerator.GenerateMaze();

        Debug.Log("Laberinto generado.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
