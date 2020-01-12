using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    [SerializeField] Transform windDirection;
    public bool active = true;
    bool isMoving;

    Vector2 moveVelocity = Vector2.zero;
    public float speed;

    Rigidbody2D rb;
    public Vector2 moveInput;
    WindController wind;

    public bool gotCaught = false;

    Vector2 facingDirection;
    Animator anim;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        wind = GameObject.Find("Wind").GetComponent<WindController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        setMovingDirection();
        if (active)
        {
            moveVelocity = moveInput.normalized * speed;
        }
        else
        {
            moveVelocity = Vector2.zero;
        }

        if (!gotCaught)
        {
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            Debug.Log(Input.GetAxisRaw("Horizontal"));

            if (moveInput.x != 0 || moveInput.y != 0)
            {
                if (moveInput.x == -wind.windDirection.x && moveInput.y == 0 || moveInput.y == -wind.windDirection.y && moveInput.x == 0)
                {
                    wind.StopWind();
                    gotCaught = true;
                }
            }
            else
            {
                wind.stopWind = false;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        if (moveVelocity != Vector2.zero) isMoving = true;
        else isMoving = false;
    }

    public void setMovingDirection()
    {
        facingDirection = windDirection.rotation * Vector2.right;
        if (facingDirection.x > 0.2)
        {
            anim.SetTrigger("HORIZONTAL");
            spriteRenderer.flipX = false;
        }
        else if (facingDirection.x < -0.2)
        {
            anim.SetTrigger("HORIZONTAL");
            spriteRenderer.flipX = true;
        }
        else if (facingDirection.y < -0.2)
        {
            anim.SetTrigger("DOWN");
        }
        else if (facingDirection.y > 0.2)
        {
            anim.SetTrigger("UP");
        }
    }
}
