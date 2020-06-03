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
    public float atk;
    public Rigidbody2D rig;
    #endregion 



    #region 方法
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && gameObject.tag == "PlayerBullet")
        {

            // Instantiate(Effect, other.transform.position, other.transform.rotation);
            // EffectAudio.Play();
            Destroy(other.gameObject);

            Destroy(gameObject);
        } 

          
        
        // 擊中目標為地面時，停止並固定，開啟碰撞判定(可以被玩家踩)
        if (other.gameObject.tag == "Ground" )
        {

            //  rig.velocity = new Vector2(0, 0);
            // speed = 0;
             speedF = 0;
            GetComponents<BoxCollider2D>()[0].enabled = true;
            rig.constraints = RigidbodyConstraints2D.FreezeAll;

        }
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
       
         rig.velocity = transform.right * speedF ;
        //transform.Translate(Vector2.right * speed );

        if (Mathf.Abs(transform.position.x - Camera.main.transform.position.x)>10 ) { Destroy(gameObject); }



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


