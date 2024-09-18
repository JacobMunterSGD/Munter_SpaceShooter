using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public float moveSpeed;

    Vector3 velocity = new Vector3(0, 0, 0);

    public float maxSpeed;
    public float decelerationSpeed;

    void Update()
    {
        if (Input.GetKey("up"))
        {
            PlayerMovement(0, moveSpeed);
        }

        if (Input.GetKey("down"))
        {
            PlayerMovement(0, -moveSpeed);
        }

        if (Input.GetKey("right"))
        {
            PlayerMovement(moveSpeed, 0);
        }

        if (Input.GetKey("left"))
        {
            PlayerMovement(-moveSpeed, 0);
        }

        if (!Input.anyKey)
        {
            PlayerDeceleration();
        }

        transform.position += velocity * Time.deltaTime;
        
    }

    void PlayerMovement(float x, float y)
    {
        Vector3 acceleration = new Vector3(x, y, 0);
        if ((velocity.x + acceleration.x * Time.deltaTime < maxSpeed) && (velocity.x + acceleration.x * Time.deltaTime > -maxSpeed) && (velocity.y + acceleration.y * Time.deltaTime < maxSpeed) && (velocity.y + acceleration.y * Time.deltaTime > -maxSpeed))
        {
            velocity += acceleration * Time.deltaTime;
        }
        else
        {
            print("max speed reached");
        }

    }

    void PlayerDeceleration()
    {
        float xSpeed = 0;
        float ySpeed = 0;

        if (velocity.x < 0)
            xSpeed = decelerationSpeed;
        if (velocity.x > 0)
            xSpeed = -decelerationSpeed;
        if (velocity.y < 0)
            ySpeed = decelerationSpeed;
        if (velocity.y > 0)
            ySpeed = -decelerationSpeed;

        if (velocity.x + xSpeed > 0 || velocity.x + xSpeed < 0)
        {
            xSpeed -= velocity.x;
        }
        if (velocity.y + ySpeed > 0 || velocity.y + ySpeed < 0)
        {
            ySpeed -= velocity.y;
        }

        Vector3 slowByVector = new Vector3(xSpeed, ySpeed, 0);

        velocity += slowByVector * Time.deltaTime;
    }

}
