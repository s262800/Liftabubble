using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class BubbleCollision : MonoBehaviour
{
    [SerializeField]
    private BubbleChangeSize bubbleChangeSize_cs;


    void Start()
    {
        
    }


    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            if (gameObject.GetComponent<SpriteRenderer>() != false) gameObject.GetComponent<SpriteRenderer>().enabled = false;

            foreach (Transform child in gameObject.transform) child.gameObject.GetComponent<SpriteRenderer>().enabled = false;

            if (gameObject.GetComponent<Rigidbody2D>())
            {
                gameObject.GetComponent<Rigidbody2D>().simulated = false;

            }
        }

        if (collision.gameObject.CompareTag("End"))
        {
            if (gameObject.GetComponent<SpriteRenderer>() != false) gameObject.GetComponent<SpriteRenderer>().enabled = false;

            foreach (Transform child in gameObject.transform) child.gameObject.GetComponent<SpriteRenderer>().enabled = false;

            if (gameObject.GetComponent<Rigidbody2D>())
            {
                gameObject.GetComponent<Rigidbody2D>().simulated = false;

            }
        }

        if (collision.gameObject.CompareTag("Replenish"))
        {
            bubbleChangeSize_cs.Grow();
            collision.gameObject.SetActive(false);
        }
    }
}
