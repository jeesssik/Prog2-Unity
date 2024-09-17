using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Vector2 dungeonSize;  // Tamaño del laberinto
    [SerializeField] private int startPos;         // Posición inicial
    [SerializeField] private GameObject generator;

    private IMazeGenerator mazeGenerator;

    void Start()
    {
        // Crear la fábrica y el generador usando la fábrica
        IMazeGeneratorFactory factory = new MazeGeneratorFactory();
        mazeGenerator = factory.CreateMazeGenerator(dungeonSize, startPos);

        List<Cell> maze = mazeGenerator.Generate(dungeonSize);
        
        Debug.Log("Laberinto generado.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
