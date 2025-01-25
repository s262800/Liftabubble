using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleChangeSize : MonoBehaviour
{
    [SerializeField]
    private float defshrinkRate;

    [SerializeField]
    private float blowingShrinkRate;

    private float shrinkRate;

    [SerializeField]
    private Vector2 smallSize;

    private Vector2 defaultSize;

    [SerializeField]
    private PushUp pushUp_cs;


    private bool shouldShrink = true;

    void Start()
    {
        defaultSize = new Vector2(transform.localScale.x, transform.localScale.y);
    }

    void FixedUpdate()
    {
        if (pushUp_cs.isBlowing())
        {
            shrinkRate = blowingShrinkRate;
        }
        else

            shrinkRate = defshrinkRate;

        Shrink();
        Growth();


    }

    public void Grow()
    {
        shouldShrink = false;
        
    }

    private void Growth()
    {
        if (shouldShrink) return;
        transform.localScale = Vector2.Lerp(transform.localScale, defaultSize, 10 * Time.deltaTime);
        if(transform.localScale.x == defaultSize.x)
        {
            shouldShrink = true;
        }

    }

    void Shrink()
    {
        if (!shouldShrink) return;

        transform.localScale = Vector2.Lerp(transform.localScale, smallSize, shrinkRate * Time.deltaTime);
    }


    
}
