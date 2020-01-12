using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    private List<Vector3> spawnPoints = new List<Vector3>();
    [SerializeField] float bgOffsetAmount = 0.02f;
    public GameObject checker;
    private GameObject spawnChecker;

    public double spawnDistance;

    public List<ObstacleSet> sets;
    public List<BackGroundSet> bgElements;

    void Start()
    {
        foreach (Transform child in transform) spawnPoints.Add(child.position);
        GenerateChunk(3);
    }

    public void GenerateChunk(int currentZone)
    {
        List<Vector3> toSpawn = new List<Vector3>();
        foreach (Vector3 t in spawnPoints) toSpawn.Add(t);

        Vector3 current = toSpawn[currentZone];
        toSpawn.Remove(current);

        Instantiate(sets[3].GetRandom(), current, Quaternion.identity);

        Instantiate(bgElements[Random.Range(0, bgElements.Count)].GetRandom(), current + randomOffset(), Quaternion.identity);

        foreach (Vector3 next in toSpawn)
        {
            Instantiate(sets[Random.Range(0, sets.Count - 1)].GetRandom(), next, Quaternion.identity);
            Instantiate(bgElements[Random.Range(0, bgElements.Count)].GetRandom(), next + randomOffset(), Quaternion.identity);
        }

        CreateChecker();

    }

    private Vector3 randomOffset()
    {
        float xOffset = Random.Range(-bgOffsetAmount, bgOffsetAmount);
        float yOffset = Random.Range(-bgOffsetAmount*2, bgOffsetAmount*2);
        return new Vector3(xOffset, yOffset);
    }

    public void CreateChecker()
    {
        spawnChecker = GameObject.Instantiate(checker, gameObject.transform.position, Quaternion.identity);
        
    }

    void Update()
    {
        if(spawnChecker == null)
        {
            Debug.Log("Uh oh!");
        }
        else if(GetDistance(spawnChecker.transform.position, Vector3.zero) < spawnDistance)
        {
            GenerateChunk(3);
        }
    }

    public static double GetDistance(Vector3 a, Vector3 b)
    {
        return Mathf.Sqrt(Mathf.Pow(a.x - b.x, 2) + Mathf.Pow(a.y - b.y, 2));
    }
}
