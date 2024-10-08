using CodiceApp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotProduct : MonoBehaviour
{

    public float redAngle;
    public float blueAngle;

    public float sightDistance;
    public float visionAngle;

    public GameObject target;

    void Update()
    {

        VisionCone();
        
    }

    void dotProduct()
    {
        float rAngle = redAngle * Mathf.Deg2Rad;
        float bAngle = blueAngle * Mathf.Deg2Rad;

        Vector3 redVector = new Vector3(Mathf.Cos(rAngle), Mathf.Sin(rAngle), 0);
        Vector3 blueVector = new Vector3(Mathf.Cos(bAngle), Mathf.Sin(bAngle), 0);

        Debug.DrawLine(Vector3.zero, redVector, Color.red);
        Debug.DrawLine(Vector3.zero, blueVector, Color.blue);

        Debug.DrawLine(blueVector, redVector, Color.magenta);

        if (Input.GetKeyDown("space"))
        {
            print(blueVector.x * redVector.x + blueVector.y * redVector.y);
        }
    }

    void VisionCone()
    {


        float angleInRads = visionAngle * Mathf.Deg2Rad;

        Vector3 leftVector = new Vector3(Mathf.Cos(angleInRads), Mathf.Sin(angleInRads)) * sightDistance;
        Vector3 rightVector = new Vector3(Mathf.Cos(-angleInRads), Mathf.Sin(-angleInRads)) * sightDistance;

        Debug.DrawLine(transform.position, transform.position + leftVector, Color.cyan);
        Debug.DrawLine(transform.position, transform.position + rightVector, Color.green);

        if (target != null)
        {
            Vector3 vectorToTarget = target.transform.position - transform.position;
            float targetDotProduct = Vector3.Dot(transform.right, vectorToTarget.normalized);
            float visionDotProduct = Vector3.Dot(transform.right, leftVector.normalized);

            Debug.DrawLine(transform.position, transform.position + vectorToTarget);

            if (targetDotProduct >= visionDotProduct && vectorToTarget.magnitude <= sightDistance)
            {
                print("target spotted!");
            }
        }

    }
}
