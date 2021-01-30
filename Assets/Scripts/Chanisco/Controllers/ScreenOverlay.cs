using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenOverlay : MonoBehaviour {

    public Image ownImage;
    public float speed;
    public bool OnAppear() {
        gameObject.SetActive(true);
        if (ownImage.fillAmount < 0.99f) {
            ownImage.fillAmount = Mathf.SmoothStep(ownImage.fillAmount,1,speed);
            return false;
        }else {
            ownImage.fillAmount = 1;
            return true;
        }
    }

    public bool OnDissapear() {
        if (ownImage.fillAmount > 0.01f) {
            ownImage.fillAmount = Mathf.SmoothStep(ownImage.fillAmount,0,speed);
            return false;
        }
        else {
            ownImage.fillAmount = 0;
            gameObject.SetActive(false);
            return true;
        }
    }
}
