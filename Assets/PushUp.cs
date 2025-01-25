using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum Facing
{
    ABOVE,
    BELOW,
    LEFT,
    RIGHT
}

public class PushUp : MonoBehaviour
{
    [SerializeField]
    private GameObject bubble;

    [SerializeField]
    private GameObject fan;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private float force = 0.25f;


    private Vector2 upVector;

    private Vector2 rightVector;

    private Vector2 leftVector;

    private Vector2 downVector;

    private Facing facing;

    private Vector2 direction;
    private Vector2 forceV;

    private float distanceX;
    private float distanceY;



    void Start()
    {
        upVector = new Vector2(0, 1);
        downVector = new Vector2(0, -1);
        rightVector = new Vector2(1, 0);
        leftVector = new Vector2(-1, 0);

        facing = Facing.BELOW;
    }


    void Update()
    {

        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            CreateRay();
        }

         distanceX = Mathf.Abs(fan.transform.position.x - bubble.transform.position.x);
         distanceY = Mathf.Abs(fan.transform.position.y - bubble.transform.position.y);



        if ((fan.transform.position.y > bubble.transform.position.y) && (distanceY > 1f))
        {
            facing = Facing.ABOVE;
        }

        if ((fan.transform.position.y < bubble.transform.position.y) && (distanceY > 1f))
        {

            facing = Facing.BELOW;

        }

        if ((fan.transform.position.x > bubble.transform.position.x) && (distanceX >= 3f))
        {
            facing = Facing.RIGHT;
        }

        if ((fan.transform.position.x < bubble.transform.position.x) && (distanceX >= 3f) )
        {
            facing = Facing.LEFT;
        }

        switch (facing)
        {
            case Facing.ABOVE:
                direction = Vector2.down; 
                forceV = downVector;
                fan.transform.eulerAngles = new Vector3(0, 0, 180);
                break;
            case Facing.BELOW:
                direction = Vector2.up;
                forceV = upVector;
                fan.transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case Facing.LEFT:
                direction = Vector2.right;
                forceV = rightVector;
                fan.transform.eulerAngles = new Vector3(0, 0, 270);
                break;
            case Facing.RIGHT:
                direction = Vector2.left;
                forceV = leftVector;
                fan.transform.eulerAngles = new Vector3(0, 0, 90);
                break;
        }

    }

    void CreateRay()
    {

        Debug.DrawRay(fan.transform.position, fan.transform.TransformDirection(Vector2.up) * 10f, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(fan.transform.position, fan.transform.TransformDirection(Vector2.up), 20f, layerMask);

        if (hit)
        {
            if (bubble.GetComponent<Rigidbody2D>() != null)
            {
                bubble.GetComponent<Rigidbody2D>().velocity += (forceV * force);
                Debug.Log(forceV * force);

            }
        }

    }
}
