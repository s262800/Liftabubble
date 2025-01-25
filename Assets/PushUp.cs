using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushUp : MonoBehaviour
{

    [SerializeField]
    private Transform startPoint;

    [SerializeField]
    private LayerMask layerMask;

    private float force = 0.1f;


    private Vector2 upVector;


    private Vector2 rightVector;

    private Vector2 leftVector;


    private Vector2 downVector;



    void Start()
    {
        upVector = new Vector2(0, 1);
        downVector = new Vector2(0, -1);
        rightVector = new Vector2(1, 0);
        leftVector = new Vector2(-1, 0);
    }


    void Update()
    {


        if (Input.GetKey(KeyCode.W))
        {
            Debug.DrawRay(startPoint.position, startPoint.TransformDirection(Vector2.up) * 10f, Color.red);
            
            RaycastHit2D hit = Physics2D.Raycast(startPoint.position, startPoint.TransformDirection(Vector2.up), 10f, layerMask);

            if(hit)
            {
               if(GetComponent<Rigidbody2D>() != null)
                {
                    GetComponent<Rigidbody2D>().AddForce(upVector * force);
                    
                }
            }

        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.DrawRay(startPoint.position, startPoint.TransformDirection(Vector2.right) * 10f, Color.red);

            RaycastHit2D hit = Physics2D.Raycast(startPoint.position, startPoint.TransformDirection(Vector2.right), 10f, layerMask);

            if (hit)
            {
                if (GetComponent<Rigidbody2D>() != null)
                {
                    GetComponent<Rigidbody2D>().AddForce(rightVector * force);

                }
            }

        }


        if (Input.GetKey(KeyCode.A))
        {
            Debug.DrawRay(startPoint.position, startPoint.TransformDirection(Vector2.left) * 10f, Color.red);

            RaycastHit2D hit = Physics2D.Raycast(startPoint.position, startPoint.TransformDirection(Vector2.left), 10f, layerMask);

            if (hit)
            {
                if (GetComponent<Rigidbody2D>() != null)
                {
                    GetComponent<Rigidbody2D>().AddForce(leftVector * force);

                }
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.DrawRay(startPoint.position, startPoint.TransformDirection(Vector2.down) * 10f, Color.red);

            RaycastHit2D hit = Physics2D.Raycast(startPoint.position, startPoint.TransformDirection(Vector2.down), 10f, layerMask);

            if (hit)
            {
                if (GetComponent<Rigidbody2D>() != null)
                {
                    GetComponent<Rigidbody2D>().AddForce(downVector * force );
                } 
            }
        }




    }
}
