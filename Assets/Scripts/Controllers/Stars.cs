using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    int starPosition;
    int intervalPoint;
    Vector3 interval;

    Vector3 differenceBetweenPoints;

    void Update()
    {
        DrawConstellation();
    }

    public void DrawConstellation()
    {

        if (starPosition <= 0 || starPosition > starTransforms.Count - 1)
        {
            starPosition = 1;
            differenceBetweenPoints = starTransforms[starPosition].position - starTransforms[starPosition - 1].position;
        }
        
        interval = differenceBetweenPoints / drawingTime * 0.02f;

        Vector3 drawTo = starTransforms[starPosition - 1].position + interval * intervalPoint;

        Debug.DrawLine(starTransforms[starPosition - 1].position, drawTo);

        //print(drawTo);

        if (drawTo - starTransforms[starPosition - 1].position == differenceBetweenPoints)
        {
            starPosition++;
            intervalPoint = 0;
            //print("true");
            if (starPosition > starTransforms.Count - 1)
                starPosition = 1;
            differenceBetweenPoints = starTransforms[starPosition].position - starTransforms[starPosition - 1].position;
        }
        else
        {
            intervalPoint++;
        }

    }
}