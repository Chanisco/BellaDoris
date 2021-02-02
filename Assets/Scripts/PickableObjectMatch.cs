using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectMatch : PickableObjectBase
{
    public bool isOn;

    public void TurnMatchOn()
    {
        animator.SetTrigger("TurnOn");
        isOn = true;
    }

    public void MatchFinished()
    {
        isOn = false;
        gameObject.AddComponent<BoxCollider>();
        gameObject.AddComponent<Rigidbody>();
        _char.HeldItem = null;
        transform.SetParent(null);

    }


}
