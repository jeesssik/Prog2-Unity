using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject generator;  // Objeto que contiene el generador del laberinto
    [SerializeField] private Vector2 dungeonSize = new Vector2(6, 6);  // Tamaño del laberinto
    [SerializeField] private int startPos;         // Posición inicial

    private IMazeGenerator mazeGenerator;

    void Start()
    {
        if (generator == null)
        {
            Debug.LogError("Generator GameObject no está asignado.");
            return;
        }

        mazeGenerator = generator.GetComponent<IMazeGenerator>();

        if (mazeGenerator == null)
        {
            Debug.LogError("No se encontró el componente IMazeGenerator en el objeto generator.");
            return;
        }

        // Generar el laberinto
        List<Cell> maze = mazeGenerator.Generate(dungeonSize);
        Debug.Log("Laberinto generado.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
