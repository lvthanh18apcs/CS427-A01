using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CagneyController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isMad = false;
    int health = int.MaxValue;
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
            else if (health % 15 == 0)
            {
                isMad = true;
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
