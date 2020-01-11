using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObstacle : MonoBehaviour
{
    [SerializeField] GameObject path;
    [SerializeField] GameObject obstacle;
    [SerializeField] float speed = 1f;

    List<Transform> nodes;
    Transform target;
    int pathIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        nodes = new List<Transform>();
        foreach(Transform child in path.transform)
        {
            nodes.Add(child);
        }
        obstacle = Instantiate(obstacle, nodes[pathIndex].position, Quaternion.identity);
        pathIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        if (pathIndex < nodes.Count)
        {
            target = nodes[pathIndex];
            obstacle.transform.position = Vector2.MoveTowards(obstacle.transform.position, target.position, speed * Time.deltaTime);
            if (Mathf.Approximately((obstacle.transform.position - target.position).magnitude, 0))
            {
                pathIndex++;
            }
        }
    }
}
