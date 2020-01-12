using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserController : MonoBehaviour
{
    GameObject target;
    [SerializeField] float speed = 1f;
    [SerializeField] Transform windDirection;

    Vector2 facingDirection;
    Animator anim;
    SpriteRenderer spriteRenderer;
    
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("ChasePoint");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        setMovingDirection();
    }

    public void setMovingDirection()
    {
        facingDirection = windDirection.rotation * Vector2.right;
        if(facingDirection.x > 0.2)
        {
            anim.SetTrigger("HORIZONTAL");
            spriteRenderer.flipX = false;
        }
        else if(facingDirection.x < -0.2)
        {
            anim.SetTrigger("HORIZONTAL");
            spriteRenderer.flipX = true;
        }
        else if(facingDirection.y < -0.2)
        {
            anim.SetTrigger("DOWN");
        }
        else if(facingDirection.y > 0.2)
        {
            anim.SetTrigger("UP");
        }
    }
}
