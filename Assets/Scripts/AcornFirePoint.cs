using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornFirePoint : MonoBehaviour
{

    // Update is called once per frame
    bool isCreating = false;
    int now;

    public Transform firePoint;
    public GameObject AcornPrefab;
    public Animator boss_anim;
    private void Start()
    {
        boss_anim = GetComponent<CagneyController>().anim;    
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (GetComponent<CagneyController>().isMad == 1)
        {
            now = System.DateTime.Now.Second;
            isCreating = true;
            GetComponent<CagneyController>().isMad = 0;
        }
        if (System.DateTime.Now.Second == now + 1 && isCreating)
        {
            boss_anim.SetBool("isCreating", true);
            boss_anim.SetBool("isMad", false);
            CreateAcorn();
            isCreating = false;
        }
    }

    private void CreateAcorn()
    {
        Vector3 middle = firePoint.position;
        Vector3 up = middle; up.y += 1;
        Vector3 down = middle; down.y -= 1;
        Instantiate(AcornPrefab, middle, firePoint.rotation);
        Instantiate(AcornPrefab, up, firePoint.rotation);
        Instantiate(AcornPrefab, down, firePoint.rotation);

    }
}
