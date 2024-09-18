using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public GameObject player;

    Vector3 velocity = Vector3.zero;

    public float speed;

    public float maxSpeed;

    private void Update()
    {
        moveEnemy();

        transform.position += velocity * Time.deltaTime;
    }

    void moveEnemy()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction = direction.normalized;

        Vector3 acceleration = direction.normalized * speed;
        if ((velocity.x + acceleration.x * Time.deltaTime < maxSpeed) && (velocity.x + acceleration.x * Time.deltaTime > -maxSpeed) && (velocity.y + acceleration.y * Time.deltaTime < maxSpeed) && (velocity.y + acceleration.y * Time.deltaTime > -maxSpeed))
        {
            velocity += direction.normalized * speed * Time.deltaTime;
        }
    }

}
