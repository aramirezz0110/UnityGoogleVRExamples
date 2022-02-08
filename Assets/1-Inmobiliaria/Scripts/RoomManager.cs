using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    //array de Gameobject
    [Header ("Rooms")]
    public GameObject[] rooms;
    int lastRoom;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject room in rooms)
        {
            //desactivar todas las habitaciones
            room.SetActive(false);
        }
        //activar la primera habitacion
        ChangeRoom(0);
    }
    //funcion para activar habitaciones
    public void ChangeRoom(int id)
    {
        //desactivar la ultima habitacion activada
        rooms[lastRoom].SetActive(false);
        //activar la habitacion del parametro
        rooms[id].SetActive(true);
        //guardar el indice de la ultima habitacion activada
        lastRoom = id;
    }
}
