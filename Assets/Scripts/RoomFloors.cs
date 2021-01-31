using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFloors : MonoBehaviour
{
    public int roomId;
    private EventController _eventController;
    public bool InRoom;

    private void OnEnable()
    {
        _eventController = EventController.Instance;
        _eventController.ChangedRoom += RoomHasBeenChange;


    }

    private void OnDisable()
    {
        _eventController.ChangedRoom -= RoomHasBeenChange;

    }

    public void RoomHasBeenChange(int id)
    {
        if (id == roomId)
        {
            InRoom = true;
            return;
        }
        InRoom = false;

    }

    private void OnTriggerStay(Collider other)
    {
        if (InRoom == false)
        {
            _eventController.OnChangedRoomCall(roomId);
        }
    }


}
