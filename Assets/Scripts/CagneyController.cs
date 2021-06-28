using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CagneyController : MonoBehaviour
{
    // Start is called before the first frame update
    public int isMad = 0;
    public int health = 100;
    public Animator anim;
    int now, prev;
    void Start()
    {
        prev = System.DateTime.Now.Second;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        now = System.DateTime.Now.Second;
        if (now != prev)
        {
            prev = now;
            --health;
            if (health % 5 == 0)
            {
                isMad = 1;
                anim.SetBool("isMad", true);
            }
        }
    }
}
