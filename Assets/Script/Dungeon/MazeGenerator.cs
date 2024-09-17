/* genera el laberinto*/
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : IMazeGenerator
{
    private Vector2 _dungeonSize;
    private int _startPos;
    private List<Cell> _board;

    public MazeGenerator(Vector2 dungeonSize, int startPos)
    {
        _dungeonSize = dungeonSize;
        _startPos = startPos;
        _board = new List<Cell>();
    }

    public List<Cell> Generate(Vector2 size)
    {
        _board = new List<Cell>();
        for (int i = 0; i < _dungeonSize.x; i++)
        {
            for (int j = 0; j < _dungeonSize.y; j++)
            {
                _board.Add(new Cell());
            }
        }

        int currentCell = _startPos;
        Stack<int> path = new Stack<int>();
        int k = 0;

        while (true)
        {
            k++;
            if (k > 1000) break;
            _board[currentCell].visited = true;

            if (currentCell == _board.Count - 1) break;

            List<int> neighbors = CheckNeighbors(currentCell);

            if (neighbors.Count == 0)
            {
                if (path.Count == 0) break;
                currentCell = path.Pop();
            }
            else
            {
                path.Push(currentCell);
                int newCell = neighbors[Random.Range(0, neighbors.Count)];
                _board[currentCell].ConnectTo(newCell, _board);
                currentCell = newCell;
            }
        }

        return _board;
    }

    private List<int> CheckNeighbors(int cell)
    {
        List<int> neighbors = new List<int>();

        //check arriba
        if (cell - _dungeonSize.x >= 0 && !_board[Mathf.FloorToInt(cell - _dungeonSize.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - _dungeonSize.x));
        }

        //check abajo
        if (cell + _dungeonSize.x < _board.Count && !_board[Mathf.FloorToInt(cell + _dungeonSize.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + _dungeonSize.x));
        }

        //check derecha
        if ((cell + 1) % _dungeonSize.x != 0 && !_board[Mathf.FloorToInt(cell + 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + 1));
        }

        //check izquierda
        if (cell % _dungeonSize.x != 0 && !_board[Mathf.FloorToInt(cell - 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - 1));
        }

        return neighbors;
    }
}
