using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    int[] delay = { 0, 1, 2, 2, 1, 1, 2, 0, 1, 0 };
    int ran_delay;
    int now, start;
    void Start()
    {
        ran_delay = Random.Range(0, 10);
        player = GameObject.Find("Cuphead");
        rb = GetComponent<Rigidbody2D>();
        now = System.DateTime.Now.Second;
        start = (now + delay[ran_delay])%60;
    }

    private void Update()
    {
        if (System.DateTime.Now.Second == start)
        {
            Vector3 target = player.transform.position;
            Vector3 cur = rb.position;
            rb.velocity = new Vector2(target.x - cur.x, target.y - cur.y) * 0.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == player.name)
        {
            Debug.Log(collision.name);
            Destroy(gameObject);
        }
    }
}
