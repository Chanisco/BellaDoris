using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableObjectFurnance : UsableObject
{

    public override void OnUseItem(CharacterBase characterUsingObject)
    {
        base.OnUseItem(characterUsingObject);
        if (characterUsingObject.HeldItem.GetComponent<PickableObjectMatch>() != null)
        {
            PickableObjectMatch t = characterUsingObject.HeldItem.GetComponent<PickableObjectMatch>();
            t.TurnMatchOn();
        }
    }

}
