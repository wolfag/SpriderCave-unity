using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float forceUp;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AnimateBouncy()
    {
        animator.Play("Up");
        yield return new WaitForSeconds(.5f);
        animator.Play("Down");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().BouncerPlayerWithBouncy(forceUp);
            StartCoroutine(AnimateBouncy());
        }
    }
}
