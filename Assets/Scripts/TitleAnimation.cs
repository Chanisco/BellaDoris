using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleAnimation : MonoBehaviour
{
    public Image targetImage;
    public CharacterBelladoris _char;
    public bool finished;

    public void Start()
    {
        StartCoroutine(ChangeImageAlphaSmoothFunction(true));
    }

    public void Update()
    {
        if (_char.isReading == false && finished == false)
        {
            StartCoroutine(ChangeImageAlphaSmoothFunction(false));
            finished = true;

        }
    }

    private IEnumerator ChangeImageAlphaSmoothFunction(bool turnOn)
    {
        int target = 0;
        if (turnOn == true)
        {
            target = 10;
        }
        while (targetImage.color.a != target)
        {
            Debug.Log("Test");
            targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, Mathf.Lerp(targetImage.color.a, target, 0.05f * Time.deltaTime));
            yield return new WaitForEndOfFrame();
            if (Mathf.Abs(target - targetImage.color.a) < 10)
            {
                targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, target);
                yield break;

            }

        }
    }
}
