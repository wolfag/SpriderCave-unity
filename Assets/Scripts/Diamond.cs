using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Diamond");
        if (Door.instance != null)
        {
            Door.instance.collectableCount++;
            Debug.Log("Count: " + Door.instance.collectableCount);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string targer = collision.gameObject.tag;
        if (targer == "Player")
        {
            Destroy(gameObject);
            if (Door.instance != null)
            {
                Door.instance.DecrementCollectables();
                Debug.Log("Count: " + Door.instance.collectableCount);
            }
        }
        
    }
}
