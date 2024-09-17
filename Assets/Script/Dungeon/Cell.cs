/* responsable de las celdas y cómo se conectan */

using System.Collections.Generic;

public class Cell
{
    public bool visited = false;
    public bool[] status = new bool[4]; // Puertas: 0 = arriba, 1 = abajo, 2 = derecha, 3 = izquierda

    public void ConnectTo(int newCell, List<Cell> board)
    {
        if (newCell > board.IndexOf(this)) // Derecha o abajo
        {
            if (newCell - 1 == board.IndexOf(this)) // Derecha
            {
                status[2] = true;
                board[newCell].status[3] = true;
            }
            else // Abajo
            {
                status[1] = true;
                board[newCell].status[0] = true;
            }
        }
        else // Izquierda o arriba
        {
            if (newCell + 1 == board.IndexOf(this)) // Izquierda
            {
                status[3] = true;
                board[newCell].status[2] = true;
            }
            else // Arriba
            {
                status[0] = true;
                board[newCell].status[1] = true;
            }
        }
    }
}
