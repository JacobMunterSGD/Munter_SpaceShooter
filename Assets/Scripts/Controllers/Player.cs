using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public GameObject enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public GameObject powerup;
    //List<GameObject> powerUpList = new List<GameObject>();

    List<PowerUp> powerUpList2 = new List<PowerUp>();
    public float powerUpLaunchSpeed;

    public GameObject rotationPoint;

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

        if (Input.GetKeyDown("p"))
        {
            SpawnPowerups(4, 3);
        }

        if (Input.GetKeyDown("o"))
        {
            detachPowerUps();
        }

        transform.position += velocity * Time.deltaTime;

        EnemyRadar(2, 20);

        rotatePowerUps();
        launchPowerUps();

    }
    void detachPowerUps()
    {
        //foreach (GameObject g in powerUpList)
        //{
        //    g.transform.parent = null;
        //}

        foreach (PowerUp p in powerUpList2)
        {
            p.GameObject.transform.parent = null;
            p.direction = Vector3.Normalize(p.GameObject.transform.position - transform.position);
        }
    }

    void rotatePowerUps()
    {
        rotationPoint.transform.Rotate(0, 0, 50 * Time.deltaTime);
    }

    void launchPowerUps()
    {
        //foreach (GameObject g in powerUpList)
        //{
        //    if (g.transform.parent == null)
        //    {
        //        //g.transform.position = g.transform.position + Vector3.up;
        //    }
        //}
        
        foreach (PowerUp p in powerUpList2)
        {
            if (p.GameObject.transform.parent == null)
            {
                p.GameObject.transform.position = p.GameObject.transform.position + p.direction * Time.deltaTime * powerUpLaunchSpeed;
            }
        }

    }

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        List<float> degrees = new List<float>();
        float intervalPerAngle = 360 / numberOfPowerups;

        for (int i = 0; i < numberOfPowerups; i++)
        {
            degrees.Add(i * intervalPerAngle);
        }

        List<Vector3> powerUpSpawnPoints = new List<Vector3>();

        foreach (float d in degrees)
        {
            powerUpSpawnPoints.Add(new Vector3(transform.position.x + Mathf.Cos(d * Mathf.Deg2Rad) * radius, transform.position.y + Mathf.Sin(d * Mathf.Deg2Rad) * radius, 0));
        }

        foreach (Vector3 p in powerUpSpawnPoints)
        {

            GameObject tempPowerUp = Instantiate(powerup, p, Quaternion.identity);
            tempPowerUp.transform.SetParent(rotationPoint.transform);

            PowerUp tempPowerUp2 = new PowerUp(tempPowerUp, Vector3.zero);

            //powerUpList.Add(tempPowerUp);
            powerUpList2.Add(tempPowerUp2);
            
        }

    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        List<float> degrees = new List<float>();
        float intervalPerAngle = 360 / circlePoints;

        for (int i = 0; i < circlePoints; i ++)
        {
            degrees.Add(i * intervalPerAngle);
        }

        List<Vector3> polygonPoints = new List<Vector3>();

        foreach (float d in degrees)
        {
            polygonPoints.Add(new Vector3(transform.position.x + Mathf.Cos(d * Mathf.Deg2Rad) * radius, transform.position.y + Mathf.Sin(d * Mathf.Deg2Rad) * radius, 0));
        }

        Color lineColor = Color.green;

        if (Vector3.Magnitude(enemyTransform.transform.position - transform.position) < radius)
        {
            lineColor = Color.red;
        }


        Vector3 lastPoint = Vector3.zero;

        foreach (Vector3 p in polygonPoints)
        {
            if (lastPoint != Vector3.zero)
            {
                Debug.DrawLine(lastPoint, p, lineColor);
            }
            else
            {
                Debug.DrawLine(p, polygonPoints[polygonPoints.Count - 1], lineColor);
            }
            lastPoint = p;
        }



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
            //print("max speed reached");
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

public class PowerUp
{

    public GameObject GameObject;
    public Vector3 direction;

    public PowerUp(GameObject tempGameObject, Vector3 tempDirection)
    {
        GameObject = tempGameObject;
        direction = tempDirection;
    }
}