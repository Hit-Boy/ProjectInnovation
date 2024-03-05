using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text screenRes;
    [SerializeField] private Slider slider;

    [SerializeField] private ControlCannon controlCannon;
    void Start() {
        slider.minValue = controlCannon.GetMinForce();
        slider.maxValue = controlCannon.GetMaxForce();
    }
    // Update is called once per frame
    void Update()
    {
        slider.value = controlCannon.GetFireStrength() > slider.minValue ?  controlCannon.GetFireStrength() : slider.minValue;
    }
}
