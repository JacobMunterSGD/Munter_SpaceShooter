using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineToMouse : MonoBehaviour
{

    void Update()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = 0;

        Debug.DrawLine(Vector3.zero, mouseWorldPos, Color.green);

        float angleInDegrees = Mathf.Atan2(mouseWorldPos.y, mouseWorldPos.x) * Mathf.Rad2Deg;
        print("current angle is: "+ angleInDegrees);
    }
}
