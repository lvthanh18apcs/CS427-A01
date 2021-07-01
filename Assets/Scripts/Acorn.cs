using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    Vector2 velo;
    public int fireSpeed = 3;

    public Rigidbody2D rb;
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Cuphead");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        if (pos.x >= 50 || pos.x <= -50 || pos.y >= 50 || pos.x <= -50)
            Destroy(gameObject);
    }

    public void Shoot()
    {
        Vector3 target = player.transform.position;
        Vector3 cur = rb.position;
        velo.x = target.x - cur.x;
        velo.y = target.y - cur.y;
        velo.x *= 0.5f; velo.y *= 0.5f;
        rb.velocity = velo;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == player.name)
        {
            Destroy(gameObject);
            Destroy(player);
        }
    }
}
