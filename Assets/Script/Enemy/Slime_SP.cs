using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_SP : MonoBehaviour
{

    #region 欄位

    /// <summary>
    /// 以Add.Force控制速度
    /// </summary>
    public float SpeedForce;
    public float Hp;
    public Player player1;
    public float ATK;
    protected Rigidbody2D rig;
    [Header("受傷計時器")]
    public float Timer2;
    public Animator ani;
    public bool track;


    #endregion

    #region 方法

    public void damage(float ATK)
    {
        Hp -= ATK;
        Timer2 = 0;
        if (Hp <= 0)
        {
            ani.SetTrigger("Dead");
            rig.velocity = Vector3.zero;
            Invoke("dead", 0.4f);
            GetComponentsInChildren<BoxCollider2D>()[1].size = Vector2.zero;
            GetComponent<Enemy>().enabled = false;
        }


    }

    public void dead()
    {

        Destroy(gameObject);

    }





    public virtual void move()
    {




        if (player1.transform.position.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (player1.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }


        if (Mathf.Abs(player1.transform.position.x - transform.position.x) < 9.2&& Mathf.Abs(player1.transform.position.y - transform.position.y)<2)
        {
            track = true;
        }

        if (Mathf.Abs(player1.transform.position.x - transform.position.x) > 20 || Mathf.Abs(player1.transform.position.y - transform.position.y) > 6)
        {
            track = false;
        }


        if (track) rig.AddForce(transform.right * -1 * SpeedForce * rig.mass);
    }


    #endregion













    #region 事件

    protected virtual void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        player1 = FindObjectOfType<Player>();
        ani = GetComponent<Animator>();
        Timer2 = 10;



    }


    protected virtual void Update()
    {


        Timer2 += Time.deltaTime;
        ani.SetFloat("DamageTimer", Timer2);
        move();

    }



    #endregion












}
