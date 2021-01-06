using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speedForce;
    public float jumpForce;
    public float maxVelocity;

    private bool isOnGround = true;

    private Rigidbody2D myBody;
    private Animator animator;

    private bool isMoveLeft;
    private bool isMoveRight;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GameObject.Find("Jump Button").GetComponent<Button>().onClick.AddListener(() => Jump());
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Walk();
        WalkJoystick();
    }

    public void SetMoveLeft(bool val)
    {
        isMoveLeft = val;
        isMoveRight = !val;
    }

    public void StopMoving()
    {
        isMoveLeft = isMoveRight = false;
    }

    public void Jump()
    {
        if (isOnGround)
        {
            isOnGround = false;
            float forceY = jumpForce;
            myBody.AddForce(new Vector2(0f, forceY));
        }
    }

    void WalkJoystick()
    {
        float forceX = 0f;
        float velocityX = Mathf.Abs(myBody.velocity.x);
        Vector3 localScale = transform.localScale;

        if (isMoveRight)
        {
            if (velocityX < maxVelocity)
            {
                if (isOnGround)
                {
                    forceX = speedForce;
                }
                else
                {
                    forceX = speedForce * 1.1f;
                }
                
                localScale.x = 1f;
                transform.localScale = localScale;

                animator.SetBool("Walk", true);
            }
        }
        else if(isMoveLeft)
        {
            if (velocityX < maxVelocity)
            {
                if (isOnGround)
                {
                    forceX = -speedForce;
                }
                else
                {
                    forceX = -speedForce * 1.1f;
                }
            }
            localScale.x = -1f;
            transform.localScale = localScale;

            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
        myBody.AddForce(new Vector2(forceX, 0f));
    }

    void Walk()
    {
        float forceX = 0f;
        float forceY = 0f;

        float velocity = Mathf.Abs(myBody.velocity.x);
        float horizontal = Input.GetAxisRaw("Horizontal");
        

        Vector3 localScale = transform.localScale;

        if (horizontal > 0)
        {
            if (velocity < maxVelocity)
            {
                if (isOnGround)
                {
                    forceX = speedForce;
                }
                else
                {
                    forceX = speedForce * 1.1f;
                }
            }
            localScale.x = 1f;
            animator.SetBool("Walk", true);
        }
        else if (horizontal < 0)
        {
            if (velocity < maxVelocity)
            {
                if (isOnGround)
                {
                    forceX = -speedForce;
                }
                else
                {
                    forceX = -speedForce * 1.1f;
                }
            }
            localScale.x = -1f;
            animator.SetBool("Walk", true);
        }
        else {
            animator.SetBool("Walk", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (isOnGround)
            {
                isOnGround = false;
                forceY = jumpForce;
            }
        }
        transform.localScale = localScale;
        myBody.AddForce(new Vector2(forceX, forceY)); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }

        if(collision.gameObject.tag=="Border")
        {
            Destroy(gameObject);
        }
    }

    public void BouncerPlayerWithBouncy(float force)
    {
        if (isOnGround)
        {
            isOnGround = false;
            myBody.AddForce(new Vector2(0f, force)); 
        }
    }
}
