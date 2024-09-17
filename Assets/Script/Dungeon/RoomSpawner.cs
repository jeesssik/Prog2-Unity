using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] private RoomFactory _roomFactory;
   
    public void CreateRooms(List<Cell> board, Vector2 size, Vector2 offset)
    {
        for(int i = 0; i < size.x; i++)
        {
            for(int j = 0; j < size.y; j++)
            {
                Cell currentCell = board[Mathf.FloorToInt(i+j*size.x)];

                if(currentCell.visited)
                {
                  //  GameObject newRoom =   Instantiate(_room, new Vector3(i * offset.x, 0f, -j * offset.y),Quaternion.identity) as GameObject;
                    //RoomBehaviour rb = newRoom.GetComponent<RoomBehaviour>();
                    //rb.UpdateRoom(currentCell.status);

                    //newRoom.name += " " + i + "-" + j;
                }
            }
        }

    }

   /* private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            _roomFactory.Create("roomZero");
        }    
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _roomFactory.Create("roomOne");
        }    
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            _roomFactory.Create("roomTwo");
        }    
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            _roomFactory.Create("roomThree");
        }    
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            _roomFactory.Create("roomFour");
        }    
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            _roomFactory.Create("roomFive");
        }    
        if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            _roomFactory.Create("roomSix");
        }    
        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            _roomFactory.Create("roomSeven");
        }    
    }*/
}
