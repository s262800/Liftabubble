using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;

public class BubbleCollision : MonoBehaviour
{
    [SerializeField]
    private BubbleChangeSize bubbleChangeSize_cs;

    [SerializeField]
    private GameObject gameOverPopup;

    [SerializeField]
    private CanvasGroup gameOverPopupCG;

    [SerializeField]
    private Score score_cs;

    [SerializeField]
    private AudioSwap audioSwap_cs;

    [SerializeField]
    private UnityEvent e;



    void Start()
    {
        
    }


    void Update()
    {

    }

    void Dead(GameObject obj)
    {
        e.Invoke();


        if (gameObject.GetComponent<SpriteRenderer>() != false) gameObject.GetComponent<SpriteRenderer>().enabled = false;

        foreach (Transform child in gameObject.transform) child.gameObject.GetComponent<SpriteRenderer>().enabled = false;

        if (gameObject.GetComponent<Rigidbody2D>())
        {
            gameObject.GetComponent<Rigidbody2D>().simulated = false;

        }

        if (obj.GetComponent<SpriteRenderer>())
        {
            obj.GetComponent<SpriteRenderer>().enabled = true;
        }

        gameOverPopupCG.alpha = 1.0f;
        gameOverPopupCG.interactable = true;
        gameOverPopupCG.blocksRaycasts = true;

        audioSwap_cs.FadeOut();



    }

    void End(GameObject obj)
    {
        e.Invoke();
        score_cs.SetBubbleSize(bubbleChangeSize_cs.GetSize());
        score_cs.SetScoreText(); 
        gameOverPopupCG.alpha = 1.0f;
        gameOverPopupCG.interactable = true;
        gameOverPopupCG.blocksRaycasts = true;
        audioSwap_cs.FadeOut();

       
        if (gameObject.GetComponent<SpriteRenderer>() != false) gameObject.GetComponent<SpriteRenderer>().enabled = false;

        foreach (Transform child in gameObject.transform) child.gameObject.GetComponent<SpriteRenderer>().enabled = false;

        if (gameObject.GetComponent<Rigidbody2D>())
        {
            gameObject.GetComponent<Rigidbody2D>().simulated = false;

        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Dead(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("End"))
        {
            End(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Replenish"))
        {
            bubbleChangeSize_cs.Grow();
            collision.gameObject.SetActive(false);
        }
    }
}
