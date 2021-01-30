using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController: Singleton<SceneController> {
    private GameController _gameController;
    //private SaveController _saveController;
    private EventController _eventController;
    //private ConfigController _configController;

    public ScreenOverlay LoadingUI;
    public string currentScene;
	public HandlerBehaviour targetInitHandler;

    IEnumerator Start() {
        _gameController = GameController.Instance;
        //_saveController = SaveController.Instance;
        //_configController = ConfigController.Instance;
        _eventController = EventController.Instance;
        while (LoadingUI.OnAppear() == false) {
            yield return new WaitForEndOfFrame();
        }
        Init();
        yield break;
       /* AsyncOperation targetScene = SceneManager.LoadSceneAsync("Init",LoadSceneMode.Additive);
        currentScene = "Init";
        while (!targetScene.isDone) {
            yield return null;
        }
        yield return new WaitForSeconds(1);
        HideLoadingScreen();
        yield break;*/
    }


    public void Init() {
        if (currentScene != string.Empty) {
            LoadingUI.gameObject.SetActive(true);
            LoadingUI.ownImage.fillAmount = 1;
            SceneManager.UnloadSceneAsync(currentScene);
        }
         /*if (_saveController.GetBoolValue(SAVED_OBJECTS.ACCEPTED_TERMS) == false) {
              StartCoroutine(AddSceneWithoutLoadin("PrivacyScene"));
         }
         else {
             CheckupMain();
         }*/
        CheckupMain();
    }

    #region allCheckUps
    public void CheckupMain() {
        if (currentScene != string.Empty) {
            SceneManager.UnloadSceneAsync(currentScene);
        }
        StartCoroutine(AddScene("Main"));
    }

    public void CheckupFeedback() {
        if (currentScene != string.Empty) {
            SceneManager.UnloadSceneAsync(currentScene);
        }
        StartCoroutine(AddScene("Feedback"));
    }

    public void CheckupConfig() {
        if (currentScene != string.Empty) {
            SceneManager.UnloadSceneAsync(currentScene);
		}
		StartCoroutine(AddSceneWithInit("Config"));
    }

    public void CheckupGame() {
        //_eventController.GameStartCall();
        if (currentScene != string.Empty) {
            SceneManager.UnloadSceneAsync(currentScene);
        }
        StartCoroutine("SetupGame");

    }

    public void CheckUpResultScreen() {
        if (currentScene != string.Empty) {
            targetInitHandler = null;
            SceneManager.UnloadSceneAsync(currentScene);
        }        //Demo Function

        if (_gameController.AllLetterGameMode) {
            CheckUpAllMode();
        }
        else {
            StartCoroutine(AddSceneWithInit("ResultScreen"));
            //#region Demo
            //int i = 0;
            //int AnatomyLength = System.Enum.GetValues(typeof(ANATOMY)).Length;
            //while (i < AnatomyLength - 1) {
            //    if (_saveController.GetIntValue(LETTERS.K,(ANATOMY)i) < 3) {
            //        StartCoroutine(AddSceneWithInit("ResultScreen"));
            //        break;
            //    }
            //    i++;
            //}
            //if (i == AnatomyLength - 1) {
            //    StartCoroutine(AddScene("Demo Einde"));

            //}
            //#endregion


        }
    }

    public void CheckUpAllMode() {
        if (currentScene != string.Empty) {
            targetInitHandler = null;
            SceneManager.UnloadSceneAsync(currentScene);
        }
        StartCoroutine(AddSceneWithoutLoadin("AllWordsConfig"));     
        
    }

    public void CheckUpTermsOfCondition(){
		if (currentScene != string.Empty) {
			SceneManager.UnloadSceneAsync(currentScene);
		}
		StartCoroutine(AddScene("PrivacyScene"));

	}

    public void CheckUpScoreScreen() {
        if (currentScene != string.Empty) {
            SceneManager.UnloadSceneAsync(currentScene);
        }
        StartCoroutine(AddScene("ScoreScreen"));

    }

    public void CheckupDiplomaScreen() {
        if (currentScene != string.Empty) {
            SceneManager.UnloadSceneAsync(currentScene);
        }
        StartCoroutine(AddScene("DiplomaArea"));

    }

    #endregion


    private IEnumerator SetupGame() {
		while (LoadingUI.OnAppear() == false) {
			yield return new WaitForEndOfFrame();
		}
		AsyncOperation tLoadGame = SceneManager.LoadSceneAsync("Game",LoadSceneMode.Additive);
		currentScene = "Game";
		while (!tLoadGame.isDone) {
			yield return null;
		}
		yield return new WaitForSeconds(1);
		_gameController.Init();
		yield break;
	}

	private IEnumerator AddSceneWithInit(string targetScene) {
		while (LoadingUI.OnAppear() == false) {
			yield return new WaitForEndOfFrame();
		}
		AsyncOperation tLoadGame = SceneManager.LoadSceneAsync(targetScene,LoadSceneMode.Additive);
		currentScene = targetScene;
		while (!tLoadGame.isDone) {
			yield return null;
		}

		while(targetInitHandler == null){
			yield return null;
		}

		while(targetInitHandler.Init() == false){
			yield return null;
		}

		yield return new WaitForSeconds(1);
		HideLoadingScreen();
		yield return new WaitForSeconds(0.2f);
		targetInitHandler.AfterLoading ();
		yield break;
	}



	private IEnumerator AddScene(string targetSceneName) {
		while (LoadingUI.OnAppear() == false) {
			yield return new WaitForEndOfFrame();
		}
		AsyncOperation targetScene = SceneManager.LoadSceneAsync(targetSceneName,LoadSceneMode.Additive);
		currentScene = targetSceneName;
		while (!targetScene.isDone) {
			yield return null;
		}
        
        yield return new WaitForSeconds(1);
		HideLoadingScreen();
		yield break;
	}

    private IEnumerator AddSceneWithoutLoadin(string targetSceneName) {
        AsyncOperation targetScene = SceneManager.LoadSceneAsync(targetSceneName,LoadSceneMode.Additive);
        currentScene = targetSceneName;
        while (!targetScene.isDone) {
            yield return null;
        }

        yield return new WaitForSeconds(1);
        HideLoadingScreen();
        yield break;
    }


    private IEnumerator OnHideLoadingScreen() {
        while (LoadingUI.OnDissapear() == false) {
            yield return new WaitForEndOfFrame();
        }
       // _eventController.SceneLoaderCompleteCall();
    }

    public void HideLoadingScreen() {
        StartCoroutine("OnHideLoadingScreen");
    }

    public string ScreenResolution() {
        string temp = Screen.currentResolution.width + "x" + Screen.currentResolution.height;
        return temp;
    }
}

public enum SCENES {
    MAIN,
    GAME,
    CONFIG,
    WIN,
	TERMS_OF_CONDITIONS
}