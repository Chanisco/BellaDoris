using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectSlotMatchBox : PickableObjectSlot
{
    public List<GameObject> Matches = new List<GameObject>();

    public GameObject matchObject;

    private void Start()
    {
        matchObject = objectInSlot.gameObject;
        CreateMatches();
    }

    public void Update()
    {
        if (objectInSlot == null)
        {
            objectInSlot = Matches[0].GetComponent<PickableObjectBase>();
            Matches.RemoveAt(0);
        }
        if (Matches.Count > 5)
        {
            return;
        }


    }

    private void CreateMatches()
    {
        for (int i = Matches.Count; i < 5; i++)
        {
            GameObject t = Instantiate(matchObject, Vector3.zero, Quaternion.identity, positionToDropItem) as GameObject;
            Matches.Add(t);
        }
    }

    public override bool PickObjectRequest(CharacterBase t)
    {
        if (t.HeldItem == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override bool PlaceObjectRequest(CharacterBase t)
    {
        return false;
    }
}
