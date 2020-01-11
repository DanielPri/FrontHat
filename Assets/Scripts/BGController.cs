using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 1f;
    public Vector2 scrollDirection;

    MeshRenderer mesh;
    Vector2 offset;
    Vector2 newPosition;

    GameObject wind;
    float windDirection;
    bool stopWind;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.sharedMaterial.SetTextureOffset("_MainTex", Vector2.zero);
        offset = Vector2.zero;
        newPosition = Vector2.zero;
        wind = GameObject.Find("Wind");
        stopWind = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopWind)
        {
            windDirection = wind.transform.rotation.eulerAngles.z;
            scrollDirection = new Vector2(Mathf.Cos(windDirection * Mathf.Deg2Rad), Mathf.Sin(windDirection * Mathf.Deg2Rad));
            newPosition = (scrollDirection * scrollSpeed * Time.deltaTime) + mesh.sharedMaterial.GetTextureOffset("_MainTex");
            mesh.sharedMaterial.SetTextureOffset("_MainTex", newPosition);
        }
        
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            StopWind();
        }*/
    }

    public void StopWind()
    {
        scrollDirection = new Vector2(0, 0);
        stopWind = true;
    }
}
