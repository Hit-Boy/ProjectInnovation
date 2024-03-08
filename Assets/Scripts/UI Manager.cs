using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text Score;
    [SerializeField] private TMP_Text Shots;
    [SerializeField] private Slider slider;

    [SerializeField] private ControlCannon controlCannon;
    private int blocksCount;
    private float currentScore;
    private float currentPercentage;

    private int shotsFired;
    void Start() {
        slider.minValue = 0;
        slider.maxValue = controlCannon.GetMaxForce();
        blocksCount = FindObjectsOfType<Break>().Length;
        
        currentScore = 0;
    }
    public void OnBreak() {
        currentScore++;
        currentPercentage = currentScore/blocksCount * 100;
        Score.text = "Destruction: " + Mathf.Ceil(currentPercentage) + "%";
        Debug.Log("CurrentScore: " + currentScore + " BlockCount: " + blocksCount);
    }

    public void OnShoot() {
        shotsFired++;
         Shots.text = "Times Fired: " + shotsFired;
    }
}
