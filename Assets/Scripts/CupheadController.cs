using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupheadController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D pBody;
    Animator pAnim;

    bool isColliding = false, isFlying = false, isDodging = false;
    public float curMoveSpeed, jumpForce = 300, gravity, moveSpeed = 5f;
    void Start()
    {
        pBody = GetComponent<Rigidbody2D>();
        pAnim = GetComponent<Animator>();
    }
    public void FinishIntro()
    {
        pAnim.SetBool("TrueDummy", true);
    }

    // Update is called once per frame
    void Update()
    {
        curMoveSpeed = 0;
        gravity = pBody.velocity.y;
        isDodging = false;

        if (Input.GetKeyDown(KeyCode.Space) && isColliding)
        {
            pBody.AddForce(new Vector2(0, jumpForce));
            isFlying = true;
        }
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && !isFlying)
        {
            isDodging = true;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            curMoveSpeed = -moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            curMoveSpeed = moveSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.name == "Cagney")
        //    Destroy(gameObject);
        if (collision.gameObject.name == "Tilemap")
        {
            isColliding = true;
            isFlying = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tilemap")
            isColliding = false;
    }

    private void FixedUpdate()
    {
        if (gameObject == null)
            return;
        Quaternion flip = transform.rotation;
        if (curMoveSpeed != 0 && isColliding)
        {
            pAnim.SetBool("isRunning", true);
            if (curMoveSpeed < 0)
            {
                flip.y = 180;
            }
            else if (curMoveSpeed > 0)
            {
                flip.y = 0;
            }
        }
        else
            pAnim.SetBool("isRunning", false);

        if (isFlying)
            pAnim.SetBool("isFlying", true);
        else
            pAnim.SetBool("isFlying", false);

        if (isDodging)
            pAnim.SetBool("isDodging", true);
        else
            pAnim.SetBool("isDodging", false);

        transform.rotation = flip;
        pBody.velocity = new Vector2(curMoveSpeed, pBody.velocity.y);
    }
}