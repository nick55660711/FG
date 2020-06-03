using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    #region 欄位
    //public float Speed = 10;
    public Rigidbody2D rig;
    public Weapon AttackType;
    public enum Weapon
    {
        弓箭 , 劍
    }

    public float FireRate;

    public float Timer;
        

    [Header("移動速度")]
    public float SpeedF;
    [Header("跳躍高度")]
    public float JumpH;
    float v;
    // public GameObject[] Ground;
    [Header("弓箭物件")]
    public GameObject Arrow;
    //public bool[] OnGround;
    private bool On_GroundAll;
    public bool OnGroundAll
    {
        get => On_GroundAll ;
    }


     RaycastHit2D hit1;
     RaycastHit2D hit2;

    [Header("生成弓箭的位置")]
    public Transform CreateObject;
    [Header("全部弓箭")]
    public GameObject[] ArrowAll;
    public bool GetBow = true;





    #endregion 



    #region 方法


    public void move() 
    {
        v = Input.GetAxis("Horizontal");
        
        if (v>0) { transform.eulerAngles = new Vector3(0, 0, 0);
        }

        else if(v<0)
        {
            transform.eulerAngles = new Vector3  (0, 180, 0);
        }

         //   transform.Translate(Speed * Mathf.Abs(v)*Time.deltaTime , 0f, 0f);
        rig.velocity = new Vector2( SpeedF * v , rig.velocity.y);

    }



    public void jump() 
    {
        if (On_GroundAll && Input.GetKeyDown("z"))
        {
            rig.AddForce(new Vector2(0, JumpH));
        }
    }


    void CreateBullet()
    {
        //產生箭
        Instantiate(Arrow, CreateObject.position, CreateObject.rotation);

        // 抓取所有有Arrow標籤的物件
        ArrowAll = GameObject.FindGameObjectsWithTag("Arrow");
        
        // 若有兩個以上Arrow物件，則摧毀最早的Arrow
        if(ArrowAll.Length > 2)
        {
            Destroy(ArrowAll[0]);
        }

    }



    public void Attack()
    {

        if (Input.GetKeyDown("x"))
        {
            //判定武器型態
            switch ((int)AttackType)
            {
                case 0: //弓
                    if (GetBow) //如果已取得弓
                    {
                        if (Timer > FireRate)
                        {

                            CreateBullet();

                            Timer = 0;
                        }

                    }

                    break;



                case 1:


                    break;




            }

        }


    }



    #endregion   







    #region 事件
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        // Ground = GameObject.FindGameObjectsWithTag("Ground") ;
        // OnGround = new bool[Ground.Length];


    }

    private void Update()
    {




        /*
        for (int i = 0; i < Ground.Length; i++)
        {
        OnGround[i] = rig.IsTouching(Ground[i].GetComponent<Collider2D>());
        }

        for (int i = 0; i < OnGround.Length; i++)
        {
            On_GroundAll = OnGround[i];
            if (OnGround[i]) { break; }
        }
        */


        #region 射線貼地判定

        // 向下射出一道射線偵測，如果有擊中目標則往下執行
        if (Physics2D.Raycast(new Vector2(transform.localPosition.x + 0.15f, transform.localPosition.y - 0.4f), Vector2.down, 0.1f))

        {
            hit1 = Physics2D.Raycast(new Vector2(transform.localPosition.x + 0.15f, transform.localPosition.y - 0.4f), Vector2.down, 0.1f);


            //若目標具有"地面"或"弓箭"標籤的物件 則判定為在地上
            if (hit1.collider.tag == "Ground" || hit1.collider.tag == "Arrow")
            {
                On_GroundAll = true;
            }
        }

        else if (Physics2D.Raycast(new Vector2(transform.localPosition.x - 0.1f, transform.localPosition.y - 0.4f), Vector2.down, 0.1f))
        {
            hit2 = Physics2D.Raycast(new Vector2(transform.localPosition.x - 0.1f, transform.localPosition.y - 0.4f), Vector2.down, 0.1f);
            if (hit2.collider.tag == "Ground" || hit2.collider.tag == "Arrow")
            {
                On_GroundAll = true;
            }
        }

        //若沒有擊中目標，則判定不在地上
        else
        {
            On_GroundAll = false;
        }

        #endregion

        move();
        jump();
        Attack();

        Timer += Time.deltaTime;



    }


    #endregion 



}
