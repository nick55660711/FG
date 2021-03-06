﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    #region 欄位
    //public float Speed = 10;
    public Rigidbody2D rig;
    public Weapon AttackType;
    public Animator ani;
    public CanvasGroup GameOverScreen;
    GameManager GM;
    Scene scene;

    [Header("受傷力道")]
    public float F1;
    public float T1;
    public float F2;
    public float T2;


    public bool Stop;
    public enum Weapon
    {
        弓箭 , 劍
    }

    [Header("可射擊弓箭數量")]
    public int ShootArrow;

    [Header("射擊間隔時間")]
    // 射擊間隔
    public float FireRate;
    /// <summary>
    /// 射擊計時器
    /// </summary>
    public float Timer;
    [Header("受傷間隔時間")]
    // 受傷間隔
    public float TimeDamage;
    /// <summary>
    /// 受傷計時器
    /// </summary>
    public float Timer2;

    [Header("跳躍判定間隔時間")]
    // 跳躍偵測時間
    public float JumpTime;
    /// <summary>
    /// 跳躍計時器
    /// </summary>
    public float Timer3;

    [Header("血量")]
    public float HP;

    [Header("移動速度")]
    public float SpeedV;
    /// <summary>
    /// 以velocity控制速度
    /// </summary>
    public float SpeedF;
    [Header("跳躍高度")]
    public float JumpH;
    public float JumpH2;
    // public GameObject[] Ground;
    [Header("弓箭物件")]
    public GameObject Arrow;


     RaycastHit2D hit1;
     RaycastHit2D hit2;

    [Header("生成弓箭的位置")]
    public Transform CreateObject;
    [Header("全部弓箭")]
    public GameObject[] ArrowAll;
    public bool GetBow = true;
    [Header("弓箭音效")]
    public AudioSource SoundManager;


    [Header("落地")]
    private bool On_GroundAll;
    public bool OnGroundAll
    {
        get => On_GroundAll ;
    }

    float v;
    float v2;



    #endregion 



    #region 方法


    public void move() 
    {
        v = Input.GetAxis("Horizontal");
        
        if (v>0) { transform.eulerAngles = new Vector3(0, 0, 0);
            v2 = 0;
        }

        else if(v<0)
        {
            transform.eulerAngles = new Vector3  (0, 180, 0);
            v2 = 1;
        }

        if(Timer2>0.1f)
        rig.velocity = new Vector2( SpeedV * v , rig.velocity.y);

        // transform.Translate(Speed * Mathf.Abs(v)*Time.deltaTime , 0f, 0f);
        
        
        // rig.AddForce(new Vector2(SpeedF * v  , 0));
        

    }
    public bool GetSword;

    public GameObject bow;
    public Sprite stay;
    public Sprite shooter;
    

    void change()
    {
        if (GetSword)
        {

            if (Input.GetKeyDown("a"))
            {
                print(AttackType);

                if ((int)AttackType == 0)
                {
                    AttackType = Weapon.劍;
                    Sword.SetActive(true);
                    bow.SetActive(false);
                    GetComponent<SpriteRenderer>().sprite = stay;
                }

                else if ((int)AttackType == 1)
                {

                    GetComponent<SpriteRenderer>().sprite = shooter;
                    bow.SetActive(true);
                    Sword.SetActive(false);
                    AttackType = Weapon.弓箭;
                }


            }

        }

    }
    public void StartShoot()
    {
        GetComponent<SpriteRenderer>().sprite = shooter;
        bow.SetActive(true);
    }

    public void jump() 
    {
        if (On_GroundAll && Input.GetKeyDown("z")&&Timer3>0.1f)
        {
            rig.AddForce(new Vector2(0, JumpH));
            Timer3 = 0;
        }


        if (Timer3 < JumpTime && Input.GetKey("z"))
        {
            rig.AddForce(new Vector2(0, JumpH2) * Time.deltaTime * 60);

        }




    }

    public AudioClip ArrowShoot;
    void CreateBullet()
    {
        SoundManager.PlayOneShot(ArrowShoot);
        //產生箭
        GameObject ArrowTemp = Instantiate(Arrow, CreateObject.position, CreateObject.rotation);
        ArrowTemp.transform.localScale = ArrowTemp.transform.localScale * CreateObject.parent.localScale.x;

        // 抓取所有有Arrow標籤的物件
        ArrowAll = GameObject.FindGameObjectsWithTag("Arrow");


        // && ArrowAll[0].GetComponent<Rigidbody2D>().velocity.x == 0

        // 若有兩個以上Arrow物件，則摧毀最早的Arrow
        if (ArrowAll.Length > ShootArrow)
        {
            Destroy(ArrowAll[0]);
        }


    }


    public GameObject Sword;

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
                        if (Timer * ShootArrow / 2 > FireRate)
                        {

                            CreateBullet();

                            Timer = 0;
                        }

                    }

                    break;


                case 1:
                    Sword.GetComponent<Sword>().Slash();

                    break;

            }

        }

    }

    public delegate void DEAD();
    public DEAD OnDead;

    bool CanBeHit;
    public void damage(float ATK)
    {

            HP -= ATK ;


            Timer2 = 0;


        if (HP <= 0)
        {
            Stop = true;
            OnDead();
            CanBeHit = false;
            rig.constraints = RigidbodyConstraints2D.FreezePositionX;
            SoundManager.Stop();
           StartCoroutine(GM.GameOver(GameOverScreen));
           

        }

      

    }

    public AudioClip hitsound;
    /// <summary>
    /// 被敵人碰撞
    /// </summary>
    /// <param name="collision">敵人傷害判定</param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CanBeHit)
        {

            if (collision.gameObject.CompareTag ("EnemyTrigger"))
            {
                if (Timer2 > TimeDamage)
                {
                    float v = Mathf.Abs(transform.position.x - collision.transform.position.x) / (transform.position.x - collision.transform.position.x);
                    damage(collision.gameObject.GetComponentInParent<Enemy>().ATK);
                    transform.Translate(v * T1, T2, 0);
                    rig.AddForce(new Vector2(v * F1, F2)*0.8f);
                    GM.HpUpdate();
                    SoundManager.PlayOneShot(hitsound,0.7f);
                }
            }



            if (collision.CompareTag("Boss"))
            {
                if (Timer2 > TimeDamage)
                {
                    float v = Mathf.Abs(transform.position.x - collision.transform.position.x) / (transform.position.x - collision.transform.position.x);
                    damage(collision.gameObject.GetComponentInParent<Boss>().ATK);
                    transform.Translate(v * T1, T2, 0);
                    rig.AddForce(new Vector2(v * F1, F2) * 0.8f);
                    GM.HpUpdate();
                    SoundManager.PlayOneShot(hitsound, 0.7f);
                }
            }

            if (collision.CompareTag("Draba"))
            {
                if (Timer2 > TimeDamage)
                {
                    float v = Mathf.Abs(transform.position.x - collision.transform.position.x) / (transform.position.x - collision.transform.position.x);
                    damage(collision.gameObject.GetComponentInParent<Draba_G>().ATK);
                    transform.Translate(v * T1, T2, 0);
                    rig.AddForce(new Vector2(v * F1, F2) * 0.8f);
                    GM.HpUpdate();
                    SoundManager.PlayOneShot(hitsound, 0.7f);
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        //如果此道具可取得 取得他
        if (other.GetComponent<ICollect>() != null) other.GetComponent<ICollect>().Get();


    }



    private void OnGround()
    {

        #region 射線貼地判定
        // 向下射出一道射線偵測，如果有擊中目標則往下執行
        if (Physics2D.Raycast(new Vector2(transform.localPosition.x + 0.15f - 0.05f * v2, transform.localPosition.y - 0.35f), Vector2.down, 
            0.08f, LayerMask.GetMask("Ground")) )
          
        {
            hit1 = Physics2D.Raycast(new Vector2(transform.localPosition.x + 0.15f - 0.05f * v2, transform.localPosition.y - 0.35f), Vector2.down, 
                0.08f, LayerMask.GetMask("Ground"));

            bool OnGround = hit1.collider.CompareTag( "Ground") || hit1.collider.CompareTag( "Arrow") ||
                hit1.collider.CompareTag( "Platform") || hit1.collider.CompareTag( "Box");
            //若目標具有"地面"或"弓箭"標籤的物件 則判定為在地上
            if (OnGround)
            {
                On_GroundAll = true;
            }
            else
            {
                On_GroundAll = false;
            }
        }

        else if (Physics2D.Raycast(new Vector2(transform.localPosition.x - 0.1f - 0.05f * v2, transform.localPosition.y - 0.35f), Vector2.down, 0.08f, LayerMask.GetMask("Ground")))
        {
            hit2 = Physics2D.Raycast(new Vector2(transform.localPosition.x - 0.1f - 0.05f * v2, transform.localPosition.y - 0.35f), Vector2.down, 0.08f, LayerMask.GetMask("Ground"));

            bool OnGround = hit2.collider.CompareTag( "Ground" )|| hit2.collider.CompareTag( "Arrow") ||
               hit2.collider.CompareTag( "Platform") || hit2.collider.CompareTag ("Box");
            if (OnGround)
            {
                On_GroundAll = true;
            }
            else
            {
                On_GroundAll = false;
            }
        }

        //若沒有擊中目標，則判定不在地上
        else
        {
            On_GroundAll = false;
        }

        #endregion

    }


    #endregion   


    public void StartScene()
    {
        if (PlayerPrefs.GetInt("Bow" + 1) == 0)
        {
            GetBow = false;
            bow.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = stay;
            GameObject.Find("弓").GetComponent<Image>().enabled = false;
        }

        if (PlayerPrefs.GetInt("Sword" + 1) == 0)
        {
            GameObject.Find("劍").GetComponent<Image>().enabled = false;
            GetSword = false;
        }
        Stop = false;
        CanBeHit = true;
        scene = SceneManager.GetActiveScene();
        SoundManager = FindObjectOfType<AudioSource>();
        print(PlayerPrefs.GetString(scene.name + "PlayerLocate"));
        if (PlayerPrefs.GetString(scene.name + "PlayerLocate") == null || PlayerPrefs.GetString(scene.name + "PlayerLocate") == "")
        {
            PlayerPrefs.SetString(scene.name + "PlayerLocate", "Start");
        }
        transform.position = GameObject.Find(PlayerPrefs.GetString(scene.name + "PlayerLocate")).transform.GetChild(0).position;


        Timer = 10;
        Timer2 = 10;
        Timer3 = 10;


    }



    #region 事件
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        GameOverScreen = GameObject.Find("GameOverScreen").GetComponent<CanvasGroup>();
        GM = FindObjectOfType<GameManager>();
        scene = SceneManager.GetActiveScene();
        SoundManager = FindObjectOfType<AudioSource>();
        GameOverScreen.alpha = 0;
        GameOverScreen.blocksRaycasts = false;
        GameOverScreen.interactable = false;
        Stop = false;
        CanBeHit = true;
        if (PlayerPrefs.GetInt("Bow"+1)==0)
        {
            GetBow = false;
            bow.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = stay;
            GameObject.Find("弓").GetComponent<Image>().enabled =false;
        }
        
        if (PlayerPrefs.GetInt("Sword"+1)==0)
        {
            GameObject.Find("劍").GetComponent<Image>().enabled = false;
            GetSword = false;
        }
        print(PlayerPrefs.GetString(scene.name + "PlayerLocate"));
        if (PlayerPrefs.GetString(scene.name + "PlayerLocate") == null || PlayerPrefs.GetString(scene.name + "PlayerLocate") =="" )
        {
            PlayerPrefs.SetString(scene.name + "PlayerLocate", "Start");
        }
        transform.position = GameObject.Find(PlayerPrefs.GetString(scene.name + "PlayerLocate")).transform.GetChild(0).position;



        // Ground = GameObject.FindGameObjectsWithTag("Ground") ;
        // OnGround = new bool[Ground.Length];

        Timer = 10;
        Timer2 = 10;
        Timer3 = 10;


    }


    public bool cheat;
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





        OnGround();
        if (!Stop)
        {
        Attack();
        jump();
        change();
        }
        if(cheat)GM.Clear();
        Timer += Time.deltaTime;
        Timer2 += Time.deltaTime;
        Timer3 += Time.deltaTime;

        ani.SetFloat("DamageTimer", Timer2);

        if (transform.localPosition.y < -5&& CanBeHit)
        {
            GetComponent<Player>().damage(100);
        }

        if (GameOverScreen.interactable == true && Input.GetKeyDown("r"))
        {
            GameOverScreen.alpha = 0;
            GameOverScreen.blocksRaycasts = false;
            GameOverScreen.interactable = false;
            GameOverScreen.GetComponentsInChildren<Image>()[1].color = new Vector4(1, 1, 1, 0);
            GameOverScreen.GetComponentsInChildren<Image>()[2].color = new Vector4(1, 1, 1, 0);
            SoundManager.Play();
            GM.Restart();
        }
    }

    private void FixedUpdate()
    {
        if (!Stop)
        {
        move();
        }
    }

    #endregion 




    public float StopDistance;

    private void OnDrawGizmos()
    {
        //圖示.顏色 = 顏色(R,G,B,A)

        Gizmos.color = new Color(1, 0, 0, 0.5f);

        Gizmos.DrawLine(new Vector2(transform.localPosition.x - 0.1f - 0.05f * v2, transform.localPosition.y - 0.35f), 
            new Vector2(transform.localPosition.x - 0.1f - 0.05f * v2, transform.localPosition.y - 0.4f));
        // 圖示.繪製線條(起點,終點)
        Gizmos.DrawLine(new Vector2(transform.localPosition.x + 0.15f - 0.05f * v2, transform.localPosition.y - 0.35f), 
            new Vector2(transform.localPosition.x + 0.15f - 0.05f * v2, transform.localPosition.y - 0.4f));


        //0.02582598
    }

}
