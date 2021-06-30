using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornFirePoint : MonoBehaviour
{

    // Update is called once per frame
    bool isCreating = false, isSpawned = false, canSpawn = false;
    int start = int.MinValue, prev, now;
    Vector3 top, middle, bot;

    public Transform firePoint;
    public GameObject AcornPrefab;
    public Animator boss_anim;
    GameObject topcorn, midcorn, botcorn;
    private void Start()
    {
        boss_anim = GetComponent<CagneyController>().anim;    
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        now = DateTime.Now.Second;
        if (prev != now)
        {
            isSpawned = false;
            prev = now;
        }
        if (GetComponent<CagneyController>().isMad)
        {
            start = DateTime.Now.Second;
            isCreating = true;
            GetComponent<CagneyController>().isMad = false;
            middle = firePoint.position;
            top = middle; top.y += 1;
            bot = middle; bot.y -= 1;
        }
        if (DateTime.Now.Second == (start + 1)%60 && canSpawn && !isSpawned && isCreating)
        {
            Acorn tmp = (Acorn)topcorn.GetComponent(typeof(Acorn));
            tmp.Shoot();
            topcorn = null;
            isSpawned = true;
        }
        else if (DateTime.Now.Second == (start + 2)%60 && canSpawn && !isSpawned && isCreating)
        {
            Acorn tmp = (Acorn)midcorn.GetComponent(typeof(Acorn));
            tmp.Shoot();
            midcorn = null;
            isSpawned = true;
        }
        else if (DateTime.Now.Second == (start + 3)%60 && canSpawn && !isSpawned && isCreating)
        {
            Acorn tmp = (Acorn)botcorn.GetComponent(typeof(Acorn));
            tmp.Shoot();
            botcorn = null;
            isSpawned = true;
            isCreating = false;
            canSpawn = false;
            boss_anim.SetBool("isFinish", true);
            boss_anim.SetBool("isCreating", false);
        }
    }
    public void CanSpawn()
    {
        start = DateTime.Now.Second;
        canSpawn = true;
        boss_anim.SetBool("isCreating", true);
        boss_anim.SetBool("isMad", false);
        topcorn = CreateAcorn(top);
        midcorn = CreateAcorn(middle);
        botcorn = CreateAcorn(bot);
        isSpawned = true;
    }

    private GameObject CreateAcorn(Vector3 pos)
    {
        return Instantiate(AcornPrefab, pos, firePoint.rotation);
    }

    IEnumerator WaitSecs(int sec)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(sec);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
