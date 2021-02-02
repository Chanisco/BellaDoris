using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectBase : MonoBehaviour
{
    public SpriteRenderer visual;
    public Animator animator;
    public CharacterBase _char;

    public void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        gameObject.tag = "Pickable";
    }
    public virtual void PickUpObject(CharacterBase t)
    {
        _char = t;
    }

    public virtual void OnPlaceObject()
    {

    }

}
