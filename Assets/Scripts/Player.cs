using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
    public bool walking;
    public Transform playerTrans;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigid.velocity = Time.deltaTime * w_speed * transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRigid.velocity = Time.deltaTime * wb_speed * -transform.forward;
        }

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
            walking = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("walkback");
            playerAnim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("walkback");
            playerAnim.SetTrigger("idle");
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(Vector3.up, -ro_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(Vector3.up, ro_speed * Time.deltaTime);
        }
        /*if (Input.GetKey(KeyCode.Space))
        {
            playerAnim.SetTrigger("jump");
            playerAnim.SetTrigger("idle");
        }*/


        if (walking)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                w_speed += rn_speed;
                playerAnim.SetTrigger("run");
                playerAnim.ResetTrigger("walk");
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                w_speed = olw_speed;
                playerAnim.ResetTrigger("run");
                playerAnim.SetTrigger("walk");
            } 
            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAnim.ResetTrigger("jump");
                playerAnim.SetTrigger("walk");
            }*/
        }
    }
}
