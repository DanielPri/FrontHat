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

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.sharedMaterial.SetTextureOffset("_MainTex", Vector2.zero);
        offset = Vector2.zero;
        newPosition = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = (scrollDirection * scrollSpeed * Time.deltaTime) + mesh.sharedMaterial.GetTextureOffset("_MainTex");
        mesh.sharedMaterial.SetTextureOffset("_MainTex", newPosition);
    }
}
