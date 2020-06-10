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

        if (player1.transform.position.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (player1.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }


        if (Timer > 1.3f + Random.Range(0.1f, 0.5f) && Mathf.Abs(player1.transform.position.x - transform.position.x) < 9.2)
        {

            rig.AddForce(transform.right * -1 * SpeedForce  * rig.mass + new Vector3(0, JumpH * rig.mass, 0));
            Timer = 0;

        }

        if (rig.velocity.y == 0)
        {
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
