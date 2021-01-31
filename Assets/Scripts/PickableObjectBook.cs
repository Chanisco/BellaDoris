using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectBook : PickableObjectBase
{
    public override void OnPlaceObject()
    {
        base.OnPlaceObject();
        animator.SetBool("Open",true);
    }
}
