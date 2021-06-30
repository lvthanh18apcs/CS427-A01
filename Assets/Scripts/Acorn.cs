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
        
    }

    public void Shoot()
    {
        Vector3 target = player.transform.position;
        Vector3 cur = rb.position;
        velo.x = target.x - cur.x;
        velo.y = target.y - cur.y;
        if (velo.x == 0)
            velo.y = fireSpeed;
        else if (velo.y == 0)
            velo.x = fireSpeed;
        else
        {
            float fx = fireSpeed / velo.x, fy = fireSpeed / velo.y;
            if (fx > fy)
                fx = fy;
            if (fx < 0) fx *= -1;
            velo.x *= fx;
            velo.y *= fx;
        }
        rb.velocity = velo;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == player.name)
        {
            Destroy(gameObject);
        }
    }
}
