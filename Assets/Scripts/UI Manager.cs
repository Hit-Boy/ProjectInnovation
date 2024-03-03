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
        slider.minValue = controlCannon.MinimumForce;
        slider.maxValue = controlCannon.MaximumForce;
    }
    // Update is called once per frame
    void Update()
    {
        slider.value = controlCannon.FireForce > slider.minValue ?  controlCannon.FireForce : slider.minValue;
    }
}
