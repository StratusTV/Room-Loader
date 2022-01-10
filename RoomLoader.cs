using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RP //Change to your namespace if you like
{
    public class RoomLoader : MonoBehaviour
    {
        //This script will enable and disable gameobjects based on distance.
        //Add this script to a empty gameobject, then tag each parent gameobject you want to be enabled or disabled "Room". any objects in the parent will be disabled or enabled using the distance
        //The script will find each parent tagged room
        //Feel free to modify this script, or rename any variables

        [SerializeField] private GameObject _player;
        [SerializeField] private float _distance = 20; //distance from room before room will render
        public List<GameObject> _activeRooms; //list of currently active rooms  
        public GameObject[] _roomsInArea; //all rooms in specific area   

        private void Awake()
        {
            _roomsInArea = GameObject.FindGameObjectsWithTag("Room");
        }

        private void Update()
        {
            foreach (GameObject room in _roomsInArea)
            {
                float distanceFromRoom = Vector3.Distance(_player.transform.position, room.transform.position);

                if (distanceFromRoom < _distance)
                {
                    if (_activeRooms.Contains(room) == false)
                    {
                        _activeRooms.Add(room);
                        room.SetActive(true);
                    }
                }

                else if (distanceFromRoom > _distance)
                {
                    _activeRooms.Remove(room);
                    room.SetActive(false);
                }
            }
        }
    }
}


    
