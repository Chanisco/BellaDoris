using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_ShowBuildVersion : MonoBehaviour
{
    public TMP_Text buildText;

    private void Start()
    {
        if (buildText == null)
        {
            buildText.GetComponent<TMP_Text>();
        }
        buildText.text = "Version : " + Application.version;
    }
}
