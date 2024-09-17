/*Interfaz contrato para la generación de laberintos.*/


using UnityEngine; 
using System.Collections.Generic;

public interface IMazeGenerator
{
    List<Cell> Generate(Vector2 size); //  retorna lista de celdas
}