using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{

    private float bubbleSize;
    private float timePassed;

    private bool isTimePassing;

    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private float maxScore;

    [SerializeField]
    private Image[] starImages;




    void Start()
    {
        isTimePassing = true;

        foreach(var image in starImages)
            image.enabled = false;
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
        foreach (var image in starImages)
            image.enabled = false;

        float score = (bubbleSize * 10000) - timePassed;
       score = Mathf.Clamp(score, 0, maxScore);
        score = Mathf.Round(score);
     // scoreText.SetText("Your score was: " + score);
        SetImages(score);
    }

    void SetImages(float score)
    {
        float s = (maxScore / score);


        if (s > (100 / 3 * 2))
        {
            starImages[2].fillAmount = (s) / 1000f;
            Debug.Log((s) / 1000f);
        }

        else if (s > (100 / 3))
        {
            starImages[1].fillAmount = (s) / 1000f;
            Debug.Log((s) / 1000f);
        }

        else
            starImages[0].fillAmount = (s) / 1000f;




    }



}
