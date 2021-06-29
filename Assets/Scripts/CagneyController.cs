using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CagneyController : MonoBehaviour
{
    // Start is called before the first frame update
    public int isMad = 0;
    int health = 20;
    public Animator anim;
    int now, prev;
    void Start()
    {
        prev = DateTime.Now.Second;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        now = DateTime.Now.Second;
        if (now != prev)
        {
            prev = now;
            --health;
            if (health == 0)
            {
                anim.SetBool("isDead", true);
            }
            else if (health % 7 == 0)
            {
                isMad = 1;
                anim.SetBool("isMad", true);
            }
        }
    }

    private void OnFinish()
    {
        anim.SetBool("isFinish", false);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
