using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindParticleController : MonoBehaviour
{
    [SerializeField] Transform wind;

    // Start is called before the first frame update
    void Start()
    {
        if(wind == null)
        {
            wind = GameObject.Find("Wind").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = wind.rotation;
    }
}
