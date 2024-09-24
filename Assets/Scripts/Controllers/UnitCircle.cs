using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UnitCircle : MonoBehaviour
{

    public List<float> angles;

    int posInList = 0;

    float radius = 5;

    Vector3 lineStartPos = new Vector3(1, -3, 0);

    float delayInSeconds = 0.5f;
    float elapsedTime;

    void Update()
    {
        Vector3 currentEndPoint = new Vector3(Mathf.Cos(angles[posInList] * Mathf.Deg2Rad), Mathf.Sin(angles[posInList] * Mathf.Deg2Rad), 0) * radius;

        Debug.DrawLine(lineStartPos, lineStartPos + currentEndPoint);

        if (Input.GetKeyDown("space"))
        {
            addToLineStart();
        }

        if (elapsedTime < delayInSeconds)
        {
            elapsedTime += Time.deltaTime;
        }
        else
        {
            addToLineStart();   
            elapsedTime = 0;
        }

    }

    void addToLineStart()
    {
        //if (posInList < angles.Count - 1)
        //{
        //    posInList++;
        //}
        //else
        //{
        //    posInList = 0;
        //}

        posInList = (posInList + 1) % angles.Count;
    }
}
