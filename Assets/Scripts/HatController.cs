using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    [SerializeField] Transform windDirection;
    public bool active = true;
    bool isMoving;

    Vector2 moveVelocity = Vector2.zero;
    Vector2 correctionVelocity = Vector2.zero;
    public float speed;

    public float borderLimit;

    Rigidbody2D rb;

    GameController gameController;

    public Vector2 moveInput;
    WindController wind;


    public bool gotCaught = false;
    public bool crashed = false;

    Vector2 facingDirection;
    Animator anim;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        wind = GameObject.Find("Wind").GetComponent<WindController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        setMovingDirection();
        if (active)
        {
            if (moveInput != Vector2.zero)
            {
                moveVelocity = moveInput.normalized * speed;

            }
            else
            {
                moveVelocity = Vector2.zero;
               
            }
        }


        else
        {
            moveVelocity = Vector2.zero;
        }

        if (!gotCaught && !crashed)
        {
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

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
        
        correctionVelocity = gameController.SetVelocityMod(isMoving);
    }

    private void FixedUpdate()
    {
        Vector2 movement = rb.position + (moveVelocity + correctionVelocity) * Time.fixedDeltaTime;
        if (CheckBounds(movement))
        {
            rb.MovePosition(movement);
        }
        else
        {
            rb.MovePosition(rb.position + (correctionVelocity) * Time.fixedDeltaTime);
        }

        if (moveVelocity != Vector2.zero) isMoving = true;
        else isMoving = false;
    }

    public bool CheckBounds(Vector2 check)
    {
        if (Mathf.Abs(check.x) >= 10.6f - borderLimit || Mathf.Abs(check.y) >= 6f - borderLimit) return false;
        else return true;
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "obstacle")
        {
            wind.StopWind();
            crashed = true;
        }
    }

 }
