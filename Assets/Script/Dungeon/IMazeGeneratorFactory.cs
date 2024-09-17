/*
Fábricas que crea instancias de generadores de laberintos. 
Separa la lógica de creación de instancias de la lógica 
de uso del generador de laberintos.
*/

using UnityEngine; 
using System.Collections.Generic;


public interface IMazeGeneratorFactory
{
    IMazeGenerator CreateMazeGenerator(Vector2 dungeonSize, int startPos);
}
