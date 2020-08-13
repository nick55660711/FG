using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region 欄位
    [Header("子彈速度")]
     // public float speed;
     public float speedF;
    // public GameObject Effect;
    // public AudioSource EffectAudio;
    [Header("攻擊力")]
    public int atk;
    public Rigidbody2D rig;
    public Sprite FireArrow;
    public AudioClip FireUp;
    #endregion 



    #region 方法
    public GameObject fireball;
    void OnTriggerEnter2D(Collider2D other)
    {
        // 擊中目標為敵人(實體)時，傷害他
        if (other.CompareTag( "Enemy") )
        {

            // Instantiate(Effect, other.transform.position, other.transform.rotation);
            // EffectAudio.Play();
            other.GetComponent<Enemy>().damage(atk);

            Destroy(gameObject);

        } 

            if (other.CompareTag("Fire"))
        {
            GetComponent<SpriteRenderer>().sprite = FireArrow;
            gameObject.tag = "Fire";

        } 

        if (other.CompareTag("Box"))
        {
            other.GetComponent<Rigidbody2D>().AddForce(transform.right * 2000);
            Destroy(gameObject);
        }
        
        if (other.CompareTag("Boss") && gameObject.CompareTag("Fire"))
        {
            if (other.transform.parent.GetComponent<Boss>().CanBeHit)
            {
                GameObject tmp = Instantiate(fireball, transform.position + transform.right * 0.8f, transform.rotation);
                tmp.transform.localScale = Vector2.one * 1.4f;
                FindObjectOfType<AudioSource>().PlayOneShot(FireUp, 0.8f);
                Destroy(tmp, 1);
            }
            other.transform.parent.GetComponent<Boss>().damage(atk);
        }

        if (other.CompareTag("Draba") && gameObject.CompareTag("Fire"))
        {
            FindObjectOfType<AudioSource>().PlayOneShot(FireUp, 0.8f);
            other.transform.GetComponent<Draba_G>().Burn();        
        }

        if (other.CompareTag("Boss") )
        {
            Destroy(gameObject); 
        }

        if (other.CompareTag("Tower"))
        {
            Destroy(gameObject);

        }



        // 擊中目標為地面時，停止並固定，開啟碰撞判定(可以被玩家踩)
        if (other.CompareTag("Ground")&& !gameObject.CompareTag("Fire"))
        {

            //  rig.velocity = new Vector2(0, 0);
            //  speed = 0;
            speedF = 0;
            GetComponents<BoxCollider2D>()[0].enabled = true;
            GetComponents<BoxCollider2D>()[1].enabled = false;
            rig.constraints = RigidbodyConstraints2D.FreezeAll;

        }
    }

  

    void Move()
    {
        rig.velocity = transform.right * speedF ;
    }

    /*
     void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Ground")
        {

            //  rig.velocity = new Vector2(0, 0);
            speed = 0;


        }
    }

    */


    #endregion 



    #region 事件
    private void Start()
    {


        // EffectAudio = GameObject.Find("bom1").GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();


    }

    void Update()
    {

        //transform.Translate(Vector2.right * speed );


        if (Mathf.Abs(transform.position.x - Camera.main.transform.position.x) > 8.8f ) { Destroy(gameObject); }



    }

    private void FixedUpdate()
    {
        Move();
    }




    /*
    if (other.tag == "Player" && gameObject.tag == "EnemyBullet")
    {
        //動態生成爆炸特效

        Instantiate(Effect, other.transform.position, other.transform.rotation);

        //爆炸音效
        EffectAudio.Play();


        other.GetComponent<Player>().HurtPlayer(atk);
        //子彈物件消滅
        Destroy(gameObject);
    }
    */
    #endregion
}


