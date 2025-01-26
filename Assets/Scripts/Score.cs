using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Score : MonoBehaviour
{

    private float bubbleSize;
    private float timePassed;

    private bool isTimePassing;

    [SerializeField]
    private TMP_Text scoreText;



    void Start()
    {
        isTimePassing = true;
    }

 

    void Update()
    {
        if(isTimePassing) timePassed += Time.deltaTime;
    }


    float GetTime()
    {
        isTimePassing = false;
        return timePassed;
    }

    public void SetBubbleSize(float size)
    {
        bubbleSize = size;
    }

   public void SetScoreText()
    {
       float score = (bubbleSize * 10000) - timePassed;
       score = Mathf.Clamp(score, 0, 99999999999);
        score = Mathf.Round(score);
      scoreText.SetText("Your score was: " + score);
    }



}
