using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableObject : MonoBehaviour
{
    public virtual bool UseObjectRequest()
    {
        return true;
    }

    public virtual void OnUseItem(CharacterBase characterUsingObject)
    {

    }
}
