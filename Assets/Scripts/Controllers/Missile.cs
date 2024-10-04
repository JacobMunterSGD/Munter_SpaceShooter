using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    Vector3 velocity;

    public void Start()
    {
        velocity = Turret.currentMissileVelocity;
        Destroy(gameObject, 15);
    }

    void Update()
    {
        transform.position = transform.position += velocity * Time.deltaTime;
    }

}