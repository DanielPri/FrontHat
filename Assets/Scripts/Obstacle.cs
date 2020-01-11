using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    List<Sprite> sprites;
    private SpriteRenderer renderer;
    Vector2 velocity;


    private void Awake()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[Random.Range(0, sprites.Count)];
    }

    public void SetVelocity(Vector2 _velocity)
    {
        velocity = _velocity;
    }
}
