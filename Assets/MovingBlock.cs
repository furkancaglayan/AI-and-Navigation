using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public Vector3 Point1, Point2;
    public float waitTime;
    public float speed = 10f;
    private bool moving = true;


    //TODO:Visualize Points and Current Position.
    void Update()
    {
        if (moving)
        {
            moving = false;
            StopAllCoroutines();
            StartCoroutine(MoveToNextPoint(waitTime));
        }
    }

    private IEnumerator MoveToNextPoint(float waitTime)
    {
        float distOne = Vector3.Distance(transform.position, Point1);
        float distTwo = Vector3.Distance(transform.position, Point2);
        Vector3 dest = distOne > distTwo ? Point1 : Point2;

        while (Vector3.Distance(transform.position, dest)>=.5f)
        {
            transform.position += (dest - transform.position).normalized*Time.deltaTime*speed;
            yield return new WaitForSeconds(.05f);
        }

        yield return new WaitForSeconds(waitTime);
        moving = true;
    }
}
