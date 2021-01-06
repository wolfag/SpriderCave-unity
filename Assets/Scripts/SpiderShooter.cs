using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
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
        Vector3 position = transform.position;
        position.y -= 0.5f;
        Instantiate(bullet, position, Quaternion.identity);
        StartCoroutine(Attack());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("GameplayController").GetComponent<GameplayController>().PlayerDied();
            Destroy(collision.gameObject);
        }
    }
}
