using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class BubbleCollision : MonoBehaviour
{
    [SerializeField]
    private BubbleChangeSize bubbleChangeSize_cs;

    [SerializeField]
    private GameObject gameOverPopup;


    void Start()
    {
        
    }


    void Update()
    {

    }

    void Dead(GameObject obj)
    {
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

        gameOverPopup.SetActive(true);


    }

    void End(GameObject obj)
    {
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

        gameOverPopup.SetActive(true);
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
