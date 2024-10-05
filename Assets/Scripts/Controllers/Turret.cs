using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float angularSpeed;
    public float targetAngle;

    public float missileSpeed;

    public GameObject player;

    public GameObject missile;

    public GameObject missileSpawnPoint;

    float timer;
    public float timerStartValue;

    public static Vector3 currentMissileVelocity;

    private void Start()
    {
        timer = timerStartValue;
    }

    void Update()
    {

        targetAngle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;

        float currentRotation = transform.rotation.eulerAngles.z;
        currentRotation = StandardizeAngle(currentRotation);

        if (targetAngle - currentRotation < 0)
        {
            if (currentRotation > targetAngle)
            {
                transform.Rotate(0, 0, -angularSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (currentRotation < targetAngle)
            {
                transform.Rotate(0, 0, angularSpeed * Time.deltaTime);
            }
        }

        if (timer >= 0)
        {
            timer -= Time.deltaTime;

            if (Vector3.Normalize(missileSpawnPoint.transform.position - transform.position) == Vector3.Normalize(player.transform.position - transform.position))
            {
                Vector3 tempVelocity = missileSpawnPoint.transform.position - transform.position;
                NewInstantiate(missile, missileSpawnPoint.transform, Vector3.Normalize(tempVelocity) * missileSpeed);
                timer = timerStartValue;
            }
        }
        else
        {
            timer = timerStartValue;
            Vector3 tempVelocity = missileSpawnPoint.transform.position - transform.position;
            NewInstantiate(missile, missileSpawnPoint.transform, Vector3.Normalize(tempVelocity) * missileSpeed);

        }

    }

    public float StandardizeAngle(float inAngle)
    {
        inAngle %= 360;
        if (inAngle > 180)
        {
            inAngle -= 360;
        }

        return inAngle;
    }

    public void NewInstantiate(GameObject gameObject, Transform transform, Vector3 velocity)
    {
        Instantiate(gameObject, transform.position, Quaternion.identity);
        currentMissileVelocity = velocity;
        //print(currentMissileVelocity);
    }

}