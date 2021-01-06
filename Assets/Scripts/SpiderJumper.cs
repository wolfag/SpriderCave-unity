using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator animator;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2, 7));
        float forceY = Random.Range(250f, 500f);
        float forceX = Random.Range(-200f, 200f);
        myBody.AddForce(new Vector2(forceX, forceY));
        animator.SetBool("Attack", true);

        yield return new WaitForSeconds(.7f);

        StartCoroutine(Attack());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string target = collision.gameObject.tag;
        if (target == "Player")
        {
            GameObject.Find("GameplayController").GetComponent<GameplayController>().PlayerDied();
            Destroy(collision.gameObject);
        }
        if (target == "Ground")
        {
            animator.SetBool("Attack", false);
        }
        if (target == "Border")
        {
            Destroy(gameObject);
        }
    }
}
