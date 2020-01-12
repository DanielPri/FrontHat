using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewObstacleSet",
    menuName = "ScriptableObjects/ObstacleSet", order = 1)]
public class ObstacleSet : ScriptableObject
{
    public List<GameObject> obstacles;

    public GameObject GetRandom()
    {
        return obstacles[Random.Range(0, obstacles.Count)];
    }

}
