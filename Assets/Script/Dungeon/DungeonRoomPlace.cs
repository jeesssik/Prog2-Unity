/*ubicación de las celdas */

using System.Collections.Generic;
using UnityEngine;

public class DungeonRoomPlacer
{
    private GameObject[] rooms;
    private Vector2 offset;
    private Vector2 _dungeonSize;
    private Dictionary<Vector2Int, GameObject> _roomInstances;

    public DungeonRoomPlacer(GameObject[] rooms, Vector2 offset, Vector2 dungeonSize)
    {
        this.rooms = rooms;
        this.offset = offset;
        this._dungeonSize = dungeonSize;
        _roomInstances = new Dictionary<Vector2Int, GameObject>();
    }

    public void PlaceRooms(List<Cell> board)
    {
        for (int i = 0; i < _dungeonSize.x; i++)
        {
            for (int j = 0; j < _dungeonSize.y; j++)
            {
                Cell currentCell = board[Mathf.FloorToInt(i + j * _dungeonSize.x)];

                if (currentCell.visited)
                {
                    Vector2Int position = new Vector2Int(i, j);

                    if (_roomInstances.ContainsKey(position)) continue;

                    int randomRoom = Random.Range(0, rooms.Length);
                    GameObject newRoom = Object.Instantiate(rooms[randomRoom], new Vector3(i * offset.x, 0f, -j * offset.y), Quaternion.identity);
                    RoomBehaviour rb = newRoom.GetComponent<RoomBehaviour>();
                    rb.UpdateRoom(currentCell.status);

                    if (i == 0 && j == 0) rb.ClearEnemies();

                    newRoom.name += " " + i + "-" + j;
                    _roomInstances.Add(position, newRoom);
                }
            }
        }
    }
}
