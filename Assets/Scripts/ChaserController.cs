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
    Rigidbody2D rb;
    Vector2 correctionVelocity;

    void Start()
    {
        correctionVelocity = Vector2.zero;
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("ChasePoint");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.fixedDeltaTime);
        setMovingDirection();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(Vector2.MoveTowards(rb.position, target.transform.position, speed * Time.fixedDeltaTime) + (correctionVelocity) * Time.fixedDeltaTime);
    }

    public void setCorrectionVelocity(Vector2 input)
    {
        correctionVelocity = input;
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
