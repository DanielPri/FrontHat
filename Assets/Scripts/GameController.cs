using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public float speed;
    public float speedMod;
    public Vector2 direction;

    GameObject player;

    public ObstacleGenerator northSpawner;
    public ObstacleGenerator southSpawner;
    public ObstacleGenerator westSpawner;
    public ObstacleGenerator eastSpawner;

    public List<Obstacle> staticObstacles;
    public List<Obstacle> dynamicObstacles;

    private void Start()
    {
        northSpawner = transform.Find("NORTH").gameObject.GetComponent<ObstacleGenerator>();
        southSpawner = transform.Find("SOUTH").gameObject.GetComponent<ObstacleGenerator>();
        westSpawner = transform.Find("WEST").gameObject.GetComponent<ObstacleGenerator>();
        eastSpawner = transform.Find("EAST").gameObject.GetComponent<ObstacleGenerator>();
    }

    public void SetDirection(float angle)
    {
        direction = new Vector2(-Mathf.Cos(Mathf.Deg2Rad * angle), -Mathf.Sin(Mathf.Deg2Rad * angle)).normalized;
        foreach(Obstacle ob in staticObstacles)
        {
            ob.SetVelocity(GetVelocity());
        }
        //Debug.Log(direction);

    }

    public void SpawnAll()
    {
        northSpawner.GenerateChunk(3);
        southSpawner.GenerateChunk(3);
        westSpawner.GenerateChunk(3);
        eastSpawner.GenerateChunk(3);
    }

    public Vector2 GetVelocity()
    {
        return direction * speed + direction * speedMod;
    }

    public Vector2 GetVelocityMod()
    {
        return direction * speedMod;
    }
}
