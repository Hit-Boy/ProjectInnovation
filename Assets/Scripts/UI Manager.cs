using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text screenRes;

    // Update is called once per frame
    void Update()
    {
        string text = "Touches on screen: " + Input.touchCount;
        screenRes.text = text;
    }
}
