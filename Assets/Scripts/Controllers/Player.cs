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

        print(velocity.x + " " + velocity.y);
    }

}
