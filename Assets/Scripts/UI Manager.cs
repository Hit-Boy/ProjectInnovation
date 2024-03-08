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
    [SerializeField] private Image image;

    [SerializeField] private Sprite[] sprites;
    private int blocksCount;
    private float currentScore;
    private float currentPercentage;
    private int shotsFired;
    private ControlCannon controlCannon;
    void Start() {
        controlCannon = FindObjectOfType<ControlCannon>();
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
        if(currentPercentage >= 100)
        {
            Invoke("EndGame",1.5f);
            GetComponent<AudioSource>().Play();
        }
    }

    public void OnShoot() {
        shotsFired++;
         Shots.text = "Fired: " + shotsFired;
    }

    void EndGame() {
        controlCannon.enabled = false;
        Score.gameObject.SetActive(false);
        image.transform.parent.gameObject.SetActive(true);
        image.sprite = sprites[0];
        Invoke("Star1",0.3f);
    }

    void Star1(){
        image.sprite = sprites[1];
        if(shotsFired <= 30)
            Invoke("Star2",0.3f);
    }

    void Star2(){
        image.sprite = sprites[2];
        if(shotsFired <= 20)
            Invoke("Star3",0.3f);
    }

    void Star3(){
        image.sprite = sprites[3];
    }

    public void ExitGame() {
        Application.Quit();
    }
}
