using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Cuphead");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    public void Shoot()
    {
        Vector3 target = player.transform.position;
        Vector3 cur = rb.position;
        rb.velocity = new Vector2(target.x - cur.x, target.y - cur.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == player.name)
        {
            Destroy(gameObject);
        }
    }
}
