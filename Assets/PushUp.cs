using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushUp : MonoBehaviour
{

    [SerializeField]
    private Transform startPoint;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private float force = 0.25f;


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
           // Debug.DrawRay(startPoint.position, startPoint.TransformDirection(Vector2.up) * 1, Color.red);


            CreateRay(Vector2.up, upVector);

        }

        if (Input.GetKey(KeyCode.D))
        {
          //  Debug.DrawRay(startPoint.position, startPoint.TransformDirection(Vector2.right) * 1, Color.red);

            CreateRay(Vector2.right, rightVector);

        }


        if (Input.GetKey(KeyCode.A))
        {
          //  Debug.DrawRay(startPoint.position, startPoint.TransformDirection(Vector2.left) * 1, Color.red);

            CreateRay(Vector2.left, leftVector);

        }

        if (Input.GetKey(KeyCode.S))
        {
        //    Debug.DrawRay(startPoint.position, startPoint.TransformDirection(Vector2.down) * 1, Color.red);

          CreateRay (Vector2.down, downVector);
        }




    }

    void CreateRay(Vector2 dir, Vector2 forceV)
    {

        Debug.DrawRay(startPoint.position, startPoint.TransformDirection(dir) * 10f, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(startPoint.position, startPoint.TransformDirection(dir), 20f, layerMask);

        if (hit)
        {
            if (GetComponent<Rigidbody2D>() != null)
            {
                GetComponent<Rigidbody2D>().velocity += (forceV * force);
                Debug.Log(forceV * force);

            }
        }

    }
}
