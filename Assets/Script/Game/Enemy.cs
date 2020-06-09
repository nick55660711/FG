using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    #region 欄位
    public float Timer;
    public float JumpH;
    /// <summary>
    /// 以Add.Force控制速度
    /// </summary>
    public float SpeedForce;
    public int Hp;
    public Player player1;
    public int ATK;

    Rigidbody2D rig;
    public float Timer2;
    public Animator ani;

    public Collider2D[] BoxCol;


    #endregion

    #region 方法

    public void damage(int ATK)
    {
        Hp -= ATK ;
        Timer2 = 0;
        if (Hp <= 0)
        {
            Destroy(gameObject);
        }


    }
   


    public void move()
    {

        float v = 0 ;

       // if (GameObject.Find("Player 1"))
            
        if (player1.transform.position.x < transform.position.x)
            {
                v = -1;

            }
            
        if (player1.transform.position.x > transform.position.x)
            {
                v = 1;

            }


        if(Timer > 1.3f + Random.Range(0.1f,0.5f) && Mathf.Abs(player1.transform.position.x - transform.position.x) < 9.2)
        {


            rig.AddForce(transform.right * SpeedForce * v * rig.mass  + new Vector3(0, JumpH * rig.mass, 0 ));
            Timer = 0;

        }

        if (rig.velocity.y == 0)
        {
            rig.velocity = new Vector2(0,0);
        }


    }



    #endregion













    #region 事件

    private void Start()
    {
        rig =  GetComponent<Rigidbody2D>();
        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        ani = GetComponent<Animator>();
        Timer2 = 10;

        BoxCol = GetComponents<BoxCollider2D>();


    }


    void Update()
    {


        Timer += Time.deltaTime;
        move();


        Timer2 += Time.deltaTime;
        ani.SetFloat("DamageTimer", Timer2);

        



    }

    #endregion












}
