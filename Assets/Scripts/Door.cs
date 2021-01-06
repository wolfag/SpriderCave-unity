using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door instance;

    private Animator animator;
    private BoxCollider2D boxCollider2D;

    [HideInInspector]
    public int collectableCount;

    private void Awake()
    {
        Debug.Log("Hello");
        MakeInstance();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void DecrementCollectables()
    {
        collectableCount--;
        if (collectableCount == 0)
        {
            StartCoroutine(Open());
        }
    }

    IEnumerator Open()
    {
        animator.Play("Open");
        yield return new WaitForSeconds(.7f);
        boxCollider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.Find("GameplayController").GetComponent<GameplayController>().PlayerDied(); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Door");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
