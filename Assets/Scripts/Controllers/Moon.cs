using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;

    List<float> degrees = new List<float>();
    List<Vector3> orbitSteps = new List<Vector3>();

    int stepNumber;

    public float waitFor;

    private void Start()
    {
        OrbitalMotionSetup(3, 5, planetTransform);
    }

    void Update()
    {
        OrbitalMotion();
    }

    public void OrbitalMotionSetup(float radius, float speed, Transform target)
    {
        float circumference = 2 * Mathf.PI * radius;
        float timeToOrbit = circumference / speed;
        float framesToOrbit = timeToOrbit * 60;

        float intervalPerAngle = 360 / framesToOrbit;

        for (int i = 0; i < framesToOrbit; i++)
        {
            degrees.Add(i * intervalPerAngle);
        }

        foreach (float d in degrees)
        {
            orbitSteps.Add(new Vector3(target.position.x + Mathf.Cos(d * Mathf.Deg2Rad) * radius, target.position.y + Mathf.Sin(d * Mathf.Deg2Rad) * radius, 0));
        }

        stepNumber = orbitSteps.Count - 1;

    }

    public void OrbitalMotion()
    {

        transform.position = orbitSteps[stepNumber];

        if (stepNumber - 1 < 0)
        {
            OrbitalMotionSetup(3, 5, planetTransform);
            return;
        }
        else
        {
            stepNumber--;
        }

    }

}
