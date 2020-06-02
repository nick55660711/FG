using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    #region 欄位
    public float Speed;
    public Rigidbody2D rig;
    public float JumpH;
    float v;
    public enum Weapon
    {
        弓箭 , 劍
    }

    public Weapon AttackType;


    // public GameObject[] Ground;
    public GameObject Arrow;
    //public bool[] OnGround;
    private bool On_GroundAll;
    public bool OnGroundAll
    {
        get => On_GroundAll ;
    }


    public RaycastHit2D hit1;
    public RaycastHit2D hit2;
    public Transform CreateObject;
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

            transform.Translate(Speed * Mathf.Abs(v)*Time.deltaTime , 0f, 0f);

        


    }

    public void jump() {
        if (On_GroundAll && Input.GetKeyDown("z"))
        {
            rig.AddForce(new Vector2(0, JumpH));
        }
    }


    void CreateBullet()
    {

        Instantiate(Arrow, CreateObject.position, CreateObject.rotation);
    }



    public void Attack()
    {

        if (Input.GetKeyDown("x"))
        {
            switch ((int)AttackType)
            {
                case 0:
                    CreateBullet();


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
        if (Physics2D.Raycast(new Vector2(transform.localPosition.x + 0.16f, transform.localPosition.y - 0.4f), Vector2.down, 0.1f))

        {
            hit1 = Physics2D.Raycast(new Vector2(transform.localPosition.x + 0.16f, transform.localPosition.y - 0.4f), Vector2.down, 0.1f);

            if (hit1.collider.tag == "Ground" || hit1.collider.tag == "Arrow")
            {
                On_GroundAll = true;
            }
        }
        else if (Physics2D.Raycast(new Vector2(transform.localPosition.x - 0.11f, transform.localPosition.y - 0.4f), Vector2.down, 0.1f))
        {
            hit2 = Physics2D.Raycast(new Vector2(transform.localPosition.x - 0.11f, transform.localPosition.y - 0.4f), Vector2.down, 0.1f);
            if (hit2.collider.tag == "Ground" || hit2.collider.tag == "Arrow")
            {
                On_GroundAll = true;
            }
        }

        else
        {
            On_GroundAll = false;
        }


        move();
        jump();
        Attack();


        if (transform.localPosition.y < -10)
        {
            transform.localPosition = new Vector3(-5, 2, 0);
        }

    }


    #endregion 



}
