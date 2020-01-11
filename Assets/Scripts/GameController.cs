using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public float speed;
    public float speedMod;
    public Vector2 direction;

    GameObject player;

    public List<Obstacle> staticObstacles;

    public Vector2 GetVelocity()
    {
        return direction * speed + direction * speedMod;
    }

    public Vector2 GetVelocityMod()
    {
        return direction * speedMod;
    }
}
