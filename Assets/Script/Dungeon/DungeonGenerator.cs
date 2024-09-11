using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGenerator : MonoBehaviour
{
    public class Cell
    {
        public bool visited = false;
        public bool[] status = new bool[4];
    }

    [SerializeField] Vector2 _dungeonSize;
    [SerializeField] int _startPos = 0;

    //[SerializeField] GameObject _room;
    public GameObject[] rooms;
    [SerializeField] Vector2 offset;

    List<Cell> _board;

    // Start is called before the first frame update
    void Start()
    {
        MazeGenerator();
    }


    void GenerateDungeon()
    {
        for (int i = 0; i < _dungeonSize.x; i++)
        {
            for (int j = 0; j < _dungeonSize.y; j++)
            {
                Cell currentCell = _board[Mathf.FloorToInt(i + j * _dungeonSize.x)];

                if (currentCell.visited)
                {
                    int randomRoom= Random.Range(0, rooms.Length);
                    GameObject newRoom = Instantiate(rooms[randomRoom], new Vector3(i * offset.x, 0f, -j * offset.y), Quaternion.identity) as GameObject;
                    RoomBehaviour rb = newRoom.GetComponent<RoomBehaviour>();
                    rb.UpdateRoom(currentCell.status);


                    newRoom.name += " " + i + "-" + j;
                }
            }
        }

    }


    public void MazeGenerator()
    {
        // Crear el tablero del dungeon
        _board = new List<Cell>();

        for (int i = 0; i < _dungeonSize.x; i++)
        {
            for (int j = 0; j < _dungeonSize.y; j++)
            {
                _board.Add(new Cell());
            }
        }

        // Posición inicial en el laberinto
        int currentCell = _startPos;

        // Pila que ayuda a generar el laberinto
        Stack<int> path = new Stack<int>();

        int k = 0; // Contador de seguridad para evitar bucles infinitos

        while (true)
        {
            k++;
            if (k > 1000) break; // Límite de iteraciones para evitar bucles infinitos

            // Marcar la celda actual como visitada
            _board[currentCell].visited = true;

            // Si se alcanza la última celda, termina el bucle
            if (currentCell == _board.Count - 1)
            {
                break;
            }

            // Obtener las celdas vecinas no visitadas
            List<int> neighbors = CheckNeighbors(currentCell);

            // Si no hay vecinos, retrocede
            if (neighbors.Count == 0)
            {
                if (path.Count == 0)
                {
                    break; // Si no hay más celdas en la pila, termina
                }
                else
                {
                    currentCell = path.Pop(); // Retrocede a la celda anterior
                }
            }
            else
            {
                // Agregar la celda actual a la pila
                path.Push(currentCell);

                // Elegir el primer vecino aleatoriamente
                int newCell = neighbors[Random.Range(0, neighbors.Count)];

                // Conectar la celda actual con el vecino
                if (newCell > currentCell) // Si el vecino está abajo o a la derecha
                {
                    if (newCell - 1 == currentCell) // Derecha
                    {
                        _board[currentCell].status[2] = true; // Puerta derecha en la celda actual
                        _board[newCell].status[3] = true;    // Puerta izquierda en la nueva celda
                    }
                    else // Abajo
                    {
                        _board[currentCell].status[1] = true; // Puerta abajo en la celda actual
                        _board[newCell].status[0] = true;    // Puerta arriba en la nueva celda
                    }
                }
                else // Si el vecino está arriba o a la izquierda
                {
                    if (newCell + 1 == currentCell) // Izquierda
                    {
                        _board[currentCell].status[3] = true; // Puerta izquierda en la celda actual
                        _board[newCell].status[2] = true;    // Puerta derecha en la nueva celda
                    }
                    else // Arriba
                    {
                        _board[currentCell].status[0] = true; // Puerta arriba en la celda actual
                        _board[newCell].status[1] = true;    // Puerta abajo en la nueva celda
                    }
                }

                // Si hay más vecinos disponibles, elige otro para conectar una segunda puerta
                if (neighbors.Count > 1)
                {
                    int secondCell = neighbors[Random.Range(0, neighbors.Count)];
                    if (secondCell != newCell) // Asegúrate de no repetir la celda ya conectada
                    {
                        // Conectar la puerta con la segunda celda
                        if (secondCell > currentCell)
                        {
                            if (secondCell - 1 == currentCell) // Derecha
                            {
                                _board[currentCell].status[2] = true;
                                _board[secondCell].status[3] = true;
                            }
                            else // Abajo
                            {
                                _board[currentCell].status[1] = true;
                                _board[secondCell].status[0] = true;
                            }
                        }
                        else
                        {
                            if (secondCell + 1 == currentCell) // Izquierda
                            {
                                _board[currentCell].status[3] = true;
                                _board[secondCell].status[2] = true;
                            }
                            else // Arriba
                            {
                                _board[currentCell].status[0] = true;
                                _board[secondCell].status[1] = true;
                            }
                        }
                    }
                }

                // Avanzar a la nueva celda
                currentCell = newCell;
            }
        }

        // Instanciar las habitaciones
        GenerateDungeon();
    }





    /*********************************************/



    //Chequea las celdas vecinas
    List<int> CheckNeighbors(int cell)
    {
        List<int> neighbors = new List<int>();

        //check Up
        if (cell - _dungeonSize.x >= 0 && !_board[Mathf.FloorToInt(cell - _dungeonSize.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - _dungeonSize.x));
        }

        //check Down
        if (cell + _dungeonSize.x < _board.Count && !_board[Mathf.FloorToInt(cell + _dungeonSize.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + _dungeonSize.x));
        }

        //check Right
        if ((cell + 1) % _dungeonSize.x != 0 && !_board[Mathf.FloorToInt(cell + 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + 1));
        }

        //check Left
        if (cell % _dungeonSize.x != 0 && !_board[Mathf.FloorToInt(cell - 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - 1));
        }

        return neighbors;
    }


    private void OnGUI()
    {
        float w = Screen.width / 2;
        float h = Screen.height - 80;
        if (GUI.Button(new Rect(w, h, 250, 50), "Regenerate Dungeon"))
        {
            RegenerateDungeon();
        }
    }

    void RegenerateDungeon()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}