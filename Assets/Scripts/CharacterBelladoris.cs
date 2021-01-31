using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBelladoris : CharacterBase
{
    public bool isReading;
    public void StartReadingAnimation()
    {
        animator.SetBool("Reading", true);
        isReading = true;
        StartCoroutine("isReadingRoutine");
    }



    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (isStatic == false)
        {
            Movement();
            PickUpOrDropItem();
            UseItem();
        }

    }

    private IEnumerator isReadingRoutine()
    {
        while (isReading == true)
        {
            if (Input.anyKey && !(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))
            {
                animator.SetBool("Reading", false);
            }
            yield return new WaitForEndOfFrame();
        }

    }
}
