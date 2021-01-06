using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string target = collision.gameObject.tag;
        switch (target)
        {
            case "Player":
                GameObject.Find("GameplayController").GetComponent<GameplayController>().PlayerDied();
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "Border":
            case "Ground":
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
