using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : Singleton<GameController> {
    public bool gameStarted;


    public GameObject GameUI;

    public bool AllLetterGameMode = false;
    private SceneController _sceneController;
    private SaveController _saveController;

    public bool playAgainPressed;
    public bool OwlIsActive;

    private void Start() {
        _sceneController = SceneController.Instance;
        _saveController = SaveController.Instance;
    }

    public void Init() {
        StartCoroutine("StartGame");
    }

    IEnumerator StartGame() {
        SceneController.Instance.HideLoadingScreen();
        TurnGameUI(true);
        yield return new WaitForSeconds(1);
        gameStarted = true;
        yield break;
    }
    

    public void EndGame() {
        //_saveController.SetLetterElementForGame(_configController.usedLetters[0],_configController.usedLetters[1],_configController.usedLetters[2],currentAnatomy,_timeController.timePassed,amountFailed,amountRequestedHelp);
        GotoWinScreen();
    }

    public void EndAllLetterGameMode() {
        StartCoroutine("GoToAllLetterConfigDelay");
    }

    public void GotoWinScreen() {
        StartCoroutine("GoToWinDelay");
    }


    private IEnumerator GoToWinDelay() {
        AudioController.Instance.DestroyAudioButton();
        yield return new WaitForSeconds(1);
        TurnGameUI(false);
        _sceneController.CheckUpResultScreen();
    }

    private void TurnGameUI(bool active) {
        GameUI.gameObject.SetActive(active);
    }
}
