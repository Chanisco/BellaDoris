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
            Vector3 camRot = cameraObject.transform.eulerAngles;
            cameraObject.transform.position = Vector3.Lerp(camPos, cameraPos.position, 0.1f);
            cameraObject.transform.eulerAngles = Vector3.Lerp(camRot, cameraPos.eulerAngles, 0.1f);
            yield return new WaitForSeconds(0.001f);

        }

        cameraObject.transform.SetParent(cameraPos);
        cameraObject.transform.localPosition = Vector3.zero;
        cameraObject.transform.localEulerAngles = Vector3.zero;
        yield break;
    }

}
