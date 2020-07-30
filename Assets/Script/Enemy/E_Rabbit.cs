using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Rabbit : Enemy
{

    public float JumpH;
    [Header("行動計時器")]
    public float Timer;
    /// <summary>
    /// 以Add.Force控制速度
    /// </summary>




    public override void move()
    {


        // if (GameObject.Find("Player 1"))



        if (Mathf.Abs(player1.transform.position.x - transform.position.x) < 9.2)
        {
            track = true;
        }

        if (Mathf.Abs(player1.transform.position.x - transform.position.x) > 20)
        {
            track = false;
        }


        if (Timer > 1.3f + Random.Range(0.1f, 0.5f) && track)
        {

            rig.AddForce(transform.right * SpeedForce * rig.mass * Random.Range(0.8f, 1.2f) + new Vector3(0, JumpH * rig.mass * Random.Range(0.8f, 1.2f), 0));
            Timer = 0;

        }

        if (rig.velocity.y != 0) { ani.SetBool("Ground", false); }
        if (Mathf.Abs(rig.velocity.y) == 0)
        {
            ani.SetBool("Ground", true);
            if (player1.transform.position.x < transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

            if (player1.transform.position.x > transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            rig.velocity = new Vector2(0, 0);

        }



    }



    protected override void Update()
    {


        Timer += Time.deltaTime;
        move();


        Timer2 += Time.deltaTime;
        ani.SetFloat("DamageTimer", Timer2);




    }


}
