using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    #region 欄位

    /// <summary>
    /// 以Add.Force控制速度
    /// </summary>
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
            Invoke("dead", 0.4f);
        }


    }

    public void dead()
    {

        Destroy(gameObject);

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

    }



    #endregion




}
