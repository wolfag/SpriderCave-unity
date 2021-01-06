using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private Transform startPos, endPos;

    private bool isCollision;

    private Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
        ChangeDirection();
    }

    void Move()
    {
        myBody.velocity = new Vector2(transform.localScale.x, 0) * speed; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string target = collision.gameObject.tag;
        if (target == "Player")
        {
            GameObject.Find("GameplayController").GetComponent<GameplayController>().PlayerDied();
            Destroy(collision.gameObject);
        }
    }

    void ChangeDirection()
    {
        isCollision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));
        if (!isCollision)
        {
            Vector3 scale = transform.localScale;
            if (scale.x == 1f)
            {
                scale.x = -1f;
            }
            else
            {
                scale.x = 1f;
            }
            transform.localScale = scale;
        }
    }
}
