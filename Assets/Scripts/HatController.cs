using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{

    bool active = true;
    bool isMoving;

    Vector2 moveVelocity = Vector2.zero;
    public float speed;

    Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Debug.Log("Horizontal input" + Input.GetAxisRaw("Horizontal"));

        if (active)
        {
            moveVelocity = moveInput.normalized * speed;
        }
        else moveVelocity = Vector2.zero;


    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        if (moveVelocity != Vector2.zero) isMoving = true;
        else isMoving = false;
    }
}
