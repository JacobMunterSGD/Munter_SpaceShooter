using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    Vector3 Target;
    Vector3 direction;

    void Start()
    {
        RandomPoint();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Target) < arrivalDistance)
        {
            RandomPoint();
        }
        else
        {
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    void RandomPoint()
    {
        Target = new Vector3(transform.position.x + Random.Range(-maxFloatDistance, maxFloatDistance), transform.position.y + Random.Range(-maxFloatDistance, maxFloatDistance), 0);
        direction = Target - transform.position;
    }
}
