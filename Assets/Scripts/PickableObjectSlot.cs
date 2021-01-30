using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectSlot : MonoBehaviour
{
    public PickableObjectBase objectInSlot;

    public bool PickObjectRequest()
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

    public void OnPickUpItem()
    {
        objectInSlot.gameObject.SetActive(false);
        objectInSlot = null;
    }

    public void OnDropItem(GameObject obj)
    {
        obj.transform.SetParent(transform);
        obj.transform.localPosition = Vector3.zero;
        objectInSlot = obj.GetComponent<PickableObjectBase>();
        obj.SetActive(true);
    }

}
