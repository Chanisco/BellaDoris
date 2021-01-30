using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class SaveController : Singleton<SaveController> {

    /*
    public bool GetBoolValue(SAVED_OBJECTS targetBool) {
        switch (targetBool) {
            case SAVED_OBJECTS.ACCEPTED_TERMS:
            return GetBoolByInt(PlayerPrefs.GetInt("AcceptedTerms"));
            case SAVED_OBJECTS.OWL_SUPPORT_OFF:
            return GetBoolByInt(PlayerPrefs.GetInt("OwlSupport"));
            default:
            return GetBoolByInt(PlayerPrefs.GetInt("AcceptedTerms"));
        }
    }

    public void SetIntValue(SAVED_OBJECTS targetObject,int targetInt) {
        switch (targetObject) {
            case SAVED_OBJECTS.TIMES_PLAYED:
            PlayerPrefs.SetInt("TimesPlayed",targetInt);
            break;
            default:
            PlayerPrefs.SetInt("TimesPlayed",targetInt);
            break;
        }
    }


    public void SetIntValue(LetterScoreElement targetObject) {
        string temp = targetObject.targetLetter.ToString() + "_" + targetObject.targetAnatomy.ToString();
        if (PlayerPrefs.GetInt(temp) < targetObject.score) {
            PlayerPrefs.SetInt(temp,targetObject.score);
        }
    }

    public void AddToIntValue(LetterScoreElement targetObject) {
        string temp = targetObject.targetLetter.ToString() + "_" + targetObject.targetAnatomy.ToString();
        
        if (3 >= targetObject.score) {
            PlayerPrefs.SetInt(temp,targetObject.score + PlayerPrefs.GetInt(temp));
        }


    public void ResetAllLetters() {
        StartCoroutine("ResetAllLetterRoutine");
        StartCoroutine("ResetWrongAnswerAmount");
    }



    public int GetIntValue(LETTERS targetLetter,ANATOMY targetAnatomy) {
        string temp = targetLetter.ToString() + "_" + targetAnatomy.ToString();
        return PlayerPrefs.GetInt(temp);
    }*/


    public enum SAVED_OBJECTS
    {
        ACCEPTED_TERMS,
        TIMES_PLAYED,
        RECEIVED_DIPLOMA,
        FINAL_ALL_LETTER_ELEMENT,
        COMPLETED_ALL_LETTERS,
        COMPLETED_FINAL_LETTER_MODE,
        OWL_SUPPORT_OFF
    }
}