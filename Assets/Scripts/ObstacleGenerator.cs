using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator
{
    Vector3 zone1;
    Vector3 zone2;
    Vector3 zone3;

    public List<GameObject> three;
    public List<GameObject> two;
    public List<GameObject> one;
    public List<GameObject> zero;

    void GenerateChunk(int currentZone)
    {
        List<Vector3> toSpawn = new List<Vector3>();
        toSpawn.Add(zone1);
        toSpawn.Add(zone2);
        toSpawn.Add(zone3);



        Vector3 current = toSpawn[currentZone - 1];
        toSpawn.Remove(current);

        GameObject.Instantiate(three[Random.Range(0, three.Count)], current, Quaternion.identity);
    }

}
