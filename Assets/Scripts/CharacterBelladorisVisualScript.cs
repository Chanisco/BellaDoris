using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBelladorisVisualScript : MonoBehaviour
{
    private EventController _eventController;

    public CharacterBase Head;
    public GameObject VisualobjectInHand;

    public void AnimationThatMakesStatic()
    {
        Head.StopMovementForAnimationSwitch(true);
    }
    public void AnimationThatRemovesStatic()
    {
        Head.StopMovementForAnimationSwitch(false);
    }
    public void RemoveItemInHandVisual()
    {
        VisualobjectInHand.SetActive(false);
    }
    public void AddItemInHandVisual()
    {
        VisualobjectInHand.SetActive(true);
    }

    private void OnEnable()
    {
        _eventController = EventController.Instance;
        _eventController.ChangedRoomTransform += OnRoomChange;


    }

    private void OnRoomChange(Transform targetRoomTransform)
    {
        transform.eulerAngles = targetRoomTransform.eulerAngles;

    }
}
