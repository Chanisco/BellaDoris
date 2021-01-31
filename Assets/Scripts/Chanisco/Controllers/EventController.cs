using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventController : Singleton<EventController> {


    public event Action<int> ChangedRoom;
    void OnChangedRoom(int roomId)
    {
        if (ChangedRoom != null)
        {
            ChangedRoom(roomId);
        }
    }
    public void OnChangedRoomCall(int roomId)
    {
        OnChangedRoom(roomId);
    }

    public event Action<Transform> ChangedRoomTransform;
    void OnChangedRoomTransform(Transform roomId)
    {
        if (ChangedRoomTransform != null)
        {
            ChangedRoomTransform(roomId);
        }
    }
    public void OnChangedRoomTransformCall(Transform roomId)
    {
        OnChangedRoomTransform(roomId);
    }

}
