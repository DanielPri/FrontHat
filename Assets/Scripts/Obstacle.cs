using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public List<Sprite> sprites;
    private SpriteRenderer sprite;
    private double zoneOut = 30;
    Vector2 velocity;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (sprites.Count != 0)
        {
            sprite = gameObject.GetComponent<SpriteRenderer>();
            sprite.sprite = sprites[Random.Range(0, sprites.Count)];
        }
        AddToController();
        //SortLayer();
    }

    protected void AddToController()
    {
        GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        controller.staticObstacles.Add(this);
        this.SetVelocity(controller.GetVelocity());
    }

    public void SetVelocity(Vector2 _velocity)
    {
        velocity = _velocity;
    }

    private void Update()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        if (ObstacleGenerator.GetDistance(this.transform.position, Vector3.zero) > zoneOut)
        {
            if (transform.parent != null) Destroy(transform.parent.gameObject);
            else Destroy(gameObject);
        }
    }

    public void SortLayer()
    {
        sprite.sortingOrder = -(int)(transform.position.y * 100);
    }
}
