using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float angularSpeed;
    public float targetAngle;

    public GameObject player;

    void Update()
    {

        targetAngle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(0, 0, targetAngle);

        print("target angle: " + targetAngle);

        //print("player angle: " + Mathf.Atan2(player.transform.position.y, player.transform.position.x) * Mathf.Rad2Deg);

        //print("turret angle: " + turretAngle);

        //print(targetAngle);

        //transform.Rotate(0, 0, angularSpeed * Time.deltaTime);
    }
}