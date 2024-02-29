using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text screenRes;

    // Update is called once per frame
    void Update()
    {
        string text = "Screen Resolution: " + Display.main.renderingWidth + " x " + Display.main.renderingHeight;
        screenRes.text = text;
    }
}
