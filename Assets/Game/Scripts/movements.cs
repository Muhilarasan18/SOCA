using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class movements : MonoBehaviour
{
    public Animator PlayerAnim;
    public Rigidbody PlayerRigid;
    public float Walk_speed, run_speed, Runback_speed, olj_speed, ro_speed;
    public bool walking;
    public Transform PlayerTrans;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            PlayerRigid.velocity = transform.forward * Walk_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            PlayerRigid.velocity = -transform.forward * Walk_speed * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayerAnim.SetTrigger("Walk");
            PlayerAnim.ResetTrigger("Idle");
            walking = true;
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            PlayerAnim.SetTrigger("Idle");
            PlayerAnim.ResetTrigger("Walk");
            walking = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerAnim.SetTrigger("Runback");
            PlayerAnim.ResetTrigger("Idle");
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            PlayerAnim.SetTrigger("Idle");
            PlayerAnim.ResetTrigger("Runback");
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            PlayerAnim.SetTrigger("DrawGun");
            PlayerAnim.ResetTrigger("Idle");
        }
        if(walking == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Walk_speed = Walk_speed + run_speed;
                PlayerAnim.SetTrigger("Run");
                PlayerAnim.ResetTrigger("Walk");
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Walk_speed = olj_speed;
                PlayerAnim.SetTrigger("Walk");
                PlayerAnim.ResetTrigger("Run");
            }
        }
        
        else
        {
            PlayerRigid.velocity = Vector3.zero;            
        }
    }
}
