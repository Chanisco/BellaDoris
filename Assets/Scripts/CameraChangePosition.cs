using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangePosition : MonoBehaviour
{
    private EventController _eventController;

    public List<Transform> CameraPositions = new List<Transform>();
    public GameObject cameraObject;

    private void OnEnable()
    {
        _eventController = EventController.Instance;
        _eventController.ChangedRoom += ChangeCameraOnRoomId;
    }

    private void OnDisable()
    {
        _eventController.ChangedRoom -= ChangeCameraOnRoomId;

    }

    public void ChangeCameraOnRoomId(int id)
    {
        cameraPos = CameraPositions[id];
        StopCoroutine("LerptoCameraPosition");
        StartCoroutine("LerptoCameraPosition");
        _eventController.OnChangedRoomTransformCall(cameraPos);
    }

    Transform cameraPos;
    IEnumerator LerptoCameraPosition()
    {
        while (Vector3.Distance(cameraObject.transform.position, cameraPos.position) > 0.1f)
        {
            Vector3 camPos = cameraObject.transform.position;
            cameraObject.transform.position = Vector3.Lerp(camPos, cameraPos.position, 0.1f);
            cameraObject.transform.eulerAngles = cameraPos.transform.eulerAngles;
            yield return new WaitForSeconds(0.01f);

        }

        cameraObject.transform.position = cameraPos.position;
        yield break;
    }
}
