using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Init_Functions : MonoBehaviour
{
    public SceneController _sceneController;

    private void OnEnable()
    {
        _sceneController = SceneController.Instance;

    }

    private void OnDisable()
    {
        
    }

    public void GotoGame()
    {

    }

    public void GotoCredits()
    {

    }

    public void GotoQuit()
    {

    }
}
