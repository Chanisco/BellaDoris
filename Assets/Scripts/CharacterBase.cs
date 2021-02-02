using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public GameObject objectInMind;
    public PickableObjectBase HeldItem;
    public Transform visualHeldItem;

    private CharacterController controller;
    public Animator animator;
    public bool isStatic = false;
    public float speed = 0.5f;

    private void Start()
    {
        if (controller == null)
        {
            controller = GetComponent<CharacterController>();
        }
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        Init();
    }

    public virtual void Init()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void StopMovementForAnimationSwitch(bool target)
    {
        isStatic = target;
    }

    public void Movement()
    {
        float yMod = 0;
        float xMod = 0;
        Vector3 tPos = transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            xMod = -speed;
            animator.SetBool("WalkingRight", false);
            animator.SetBool("WalkingLeft", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            xMod = speed;
            animator.SetBool("WalkingLeft", false);
            animator.SetBool("WalkingRight", true);
        }
        if (Input.GetKey(KeyCode.W))
        {
            yMod = speed;
            animator.SetBool("WalkingForward", false);
            animator.SetBool("WalkingBack", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            yMod = -speed;
            animator.SetBool("WalkingBack", false);
            animator.SetBool("WalkingForward", true);
        }
        Vector3 targetVector = new Vector3(xMod, 0, yMod);
        controller.Move(targetVector * Time.deltaTime);



        if (!Input.GetKey(KeyCode.A))
        {
            animator.SetBool("WalkingLeft", false);
        }
        if (!Input.GetKey(KeyCode.D))
        {
            animator.SetBool("WalkingRight", false);
        }
        if (!Input.GetKey(KeyCode.S))
        {
            animator.SetBool("WalkingForward", false);
        }
        if (!Input.GetKey(KeyCode.W))
        {
            animator.SetBool("WalkingBack", false);
        }
    }

    public void PickUpOrDropItem()
    {
        if (objectInMind != null)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (objectInMind.GetComponent<PickableObjectSlot>() != null)
                {
                    //// if there is an object in the slot pick up the item
                    PickableObjectSlot objectSlotScript = objectInMind.GetComponent<PickableObjectSlot>();
                    if (objectSlotScript.PickObjectRequest(this) == true)
                    {
                        HeldItem = objectSlotScript.objectInSlot;
                        objectInMind = null;
                        objectSlotScript.OnPickUpItem();

                        //Own Visuals dropping the object
                        visualHeldItem.gameObject.SetActive(true);
                        HeldItem.gameObject.transform.SetParent(visualHeldItem.transform);
                        HeldItem.transform.localPosition = Vector3.zero;
                        HeldItem.gameObject.SetActive(true);
                    }                
                    //// if there is no object in the slot
                    else
                    {
                        if (HeldItem != null)
                        {
                            //Own Visuals dropping the object
                            visualHeldItem.gameObject.SetActive(false);

                            if (objectSlotScript.PlaceObjectRequest(this) == true)
                            {
                                objectSlotScript.OnDropItem(HeldItem.gameObject);
                                HeldItem = null;
                                objectInMind = null;

                            }

                        }
                    }

                }

            }
        }
    }

    public void UseItem()
    {
        if (objectInMind != null)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (objectInMind.GetComponent<UsableObject>() != null)
                {
                    //// if there is an object in the slot pick up the item
                    UsableObject objectUseScript = objectInMind.GetComponent<UsableObject>();
                    if (objectUseScript.UseObjectRequest() == true)
                    {
                        objectUseScript.OnUseItem(this);
                    }

                }

            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Pickable")
        {
            objectInMind = other.gameObject;
            if (objectInMind.GetComponent<PickableObjectSlot>().objectInSlot != null)
            {
                Debug.Log("Well we can try to grab this : " + objectInMind.GetComponent<PickableObjectSlot>().objectInSlot.name);

            }
        }
        if (other.gameObject.tag == "Useable")
        {
            objectInMind = other.gameObject;
            if (objectInMind.GetComponent<UsableObject>() != null)
            {
                Debug.Log("Lets try to use this item" + objectInMind.name);

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pickable" || other.gameObject.tag == "Useable")
        {
            objectInMind = null;
        }
    }

}
