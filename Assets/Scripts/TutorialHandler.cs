using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHandler : MonoBehaviour
{
    public int step = 0;
    public PickableObjectSlot bookSlot;
    public GameObject VisualText;

    public GameObject InvisibleWall;
    public CharacterBelladoris characterclass;
    private EventController _eventController;

    private void OnEnable()
    {
        characterclass.StartReadingAnimation();
        _eventController = EventController.Instance;
        Startstep();
    }

    private void OnDisable()
    {
        
    }

    void nextStep()
    {
        step++;
        Startstep();
    }

    void Startstep()
    {
        switch (step)
        {
            case 0:
                StartCoroutine(CheckIfBookIsPlaced());

            break;
            case 1:
                InvisibleWall.SetActive(false);
                _eventController.OnChangedRoomCall(1);
                VisualText.SetActive(false);
            break;
            default:

            break;
        }
    }

    IEnumerator CheckIfBookIsPlaced()
    {
        while(bookSlot.objectInSlot == null)
        {
             yield return new WaitForSeconds(0.5f);

        }
        nextStep();
        yield break;
    }

}
