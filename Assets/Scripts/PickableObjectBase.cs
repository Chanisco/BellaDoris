using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectBase : MonoBehaviour
{
    public SpriteRenderer visual;
    public Animator animator;

    public void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }
    public virtual void PickUpObject()
    {

    }

    public virtual void OnPlaceObject()
    {

    }

}
