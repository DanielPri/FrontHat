using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public float speed;
    public float speedMod;
    public Vector2 direction;
    public Vector2 cameraMod;

    [SerializeField] float dynamicObstacleFrequency = 5f;
    float timeSinceLastDynamicObstacle = 0;

    public Vector3 anchor = Vector3.zero;
    GameObject player;
    ChaserController chaser;


    public ObstacleGenerator northSpawner;
    public ObstacleGenerator southSpawner;
    public ObstacleGenerator westSpawner;
    public ObstacleGenerator eastSpawner;

    private GameObject chasePoint;
    public float chaseDistance;

    public List<Obstacle> staticObstacles;
    public List<GameObject> dynamicObstacles;


    private void Awake()
    {
        northSpawner = transform.Find("NORTH").gameObject.GetComponent<ObstacleGenerator>();
        southSpawner = transform.Find("SOUTH").gameObject.GetComponent<ObstacleGenerator>();
        westSpawner = transform.Find("WEST").gameObject.GetComponent<ObstacleGenerator>();
        eastSpawner = transform.Find("EAST").gameObject.GetComponent<ObstacleGenerator>();
        chasePoint = GameObject.FindGameObjectWithTag("ChasePoint");
        player = GameObject.FindGameObjectWithTag("Player");
        chaser = GameObject.Find("Chaser").GetComponent<ChaserController>();
        chasePoint.transform.localPosition = direction * chaseDistance;

    }

    public void SetDirection(float angle)
    {
        direction = new Vector2(-Mathf.Cos(Mathf.Deg2Rad * angle), -Mathf.Sin(Mathf.Deg2Rad * angle)).normalized;

    }

    private void Update()
    {
        foreach (Obstacle ob in staticObstacles)
        {
            ob.SetVelocity(GetVelocity());
        }
        
        chasePoint.transform.localPosition = direction * chaseDistance;
        spawnDynamicObstacle();
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
        return (direction * speed) + cameraMod;
    }

    public Vector2 SetVelocityMod(bool moving)
    {
        Vector2 offset = new Vector2(anchor.x - player.transform.position.x, anchor.y - player.transform.position.y);

        if (!moving) cameraMod = speedMod * offset * ObstacleGenerator.GetDistance(player.transform.position, anchor) * 0.1f;
        else cameraMod = Vector2.zero;

        chaser.setCorrectionVelocity(cameraMod);
        return cameraMod;
       
    }

    void spawnDynamicObstacle()
    {
        if(timeSinceLastDynamicObstacle >= dynamicObstacleFrequency)
        {
            timeSinceLastDynamicObstacle = 0f;
            Instantiate(dynamicObstacles[Random.Range(0, dynamicObstacles.Count)], Vector3.zero, Quaternion.identity);
        }
        timeSinceLastDynamicObstacle += Time.deltaTime;
    }
}
