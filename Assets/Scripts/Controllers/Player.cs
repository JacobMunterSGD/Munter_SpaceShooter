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

    void Update()
    {
        if (Input.GetKey("up"))
        {
            PlayerMovement(0, moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey("down"))
        {
            PlayerMovement(0, -moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey("right"))
        {
            PlayerMovement(moveSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey("left"))
        {
            PlayerMovement(-moveSpeed * Time.deltaTime, 0);
        }
    }

    void PlayerMovement(float x, float y)
    {
        Vector3 velocity = new Vector3(x, y, 0);
        transform.position += velocity;
    }

}
