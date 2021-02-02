using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectSlot : MonoBehaviour
{
    public PickableObjectBase objectInSlot;
    public Transform positionToDropItem;
    public virtual bool PickObjectRequest(CharacterBase t)
    {
        if (objectInSlot == null)
        {
            return false;
        }
        else
        {
            return true;

        }


    }

    public virtual bool PlaceObjectRequest(CharacterBase t)
    {
        if (objectInSlot != null)
        {
            return false;
        }
        else
        {
            return true;

        }
    }

    public virtual void OnPickUpItem()
    {
        objectInSlot.gameObject.SetActive(false);
        objectInSlot = null;
    }

    public virtual void OnDropItem(GameObject obj)
    {
        obj.transform.SetParent(positionToDropItem);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.eulerAngles = positionToDropItem.eulerAngles;
        objectInSlot = obj.GetComponent<PickableObjectBase>();
        objectInSlot.OnPlaceObject();
        obj.SetActive(true);
    }

}
