using UnityEngine;
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
    Transform PlayerStart;
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

        rig.velocity = new Vector2( SpeedV * v , rig.velocity.y);

        // transform.Translate(Speed * Mathf.Abs(v)*Time.deltaTime , 0f, 0f);
        
        
        // rig.AddForce(new Vector2(SpeedF * v  , 0));
        

    }
    public bool GetSword;
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
                }

                else if ((int)AttackType == 1)
                {

                    Sword.SetActive(false);
                    AttackType = Weapon.弓箭;
                }


            }

        }

    }


    public void jump() 
    {
        if (On_GroundAll && Input.GetKeyDown("z"))
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
            GameOverScreen.alpha = 1;
            GameOverScreen.blocksRaycasts = true;
            GameOverScreen.interactable = true;

        }

    }

    /// <summary>
    /// 被敵人碰撞
    /// </summary>
    /// <param name="collision">敵人傷害判定</param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CanBeHit)
        {

            if (collision.gameObject.tag == "EnemyTrigger")
            {
                if (Timer2 > TimeDamage)
                {
                    float v = Mathf.Abs(transform.position.x - collision.transform.position.x) / (transform.position.x - collision.transform.position.x);
                    damage(collision.gameObject.GetComponentInParent<Enemy>().ATK);
                    transform.Translate(v * T1, T2, 0);
                    rig.AddForce(new Vector2(v * F1, F2));
                    GM.HpUpdate();
                }
            }



            if (collision.CompareTag("Boss"))
            {
                if (Timer2 > TimeDamage)
                {
                    float v = Mathf.Abs(transform.position.x - collision.transform.position.x) / (transform.position.x - collision.transform.position.x);
                    damage(collision.gameObject.GetComponentInParent<Boss>().ATK);
                    transform.Translate(v * T1, T2, 0);
                    rig.AddForce(new Vector2(v * F1, F2));
                    GM.HpUpdate();
                }
            }

            if (collision.CompareTag("Draba"))
            {
                if (Timer2 > TimeDamage)
                {
                    float v = Mathf.Abs(transform.position.x - collision.transform.position.x) / (transform.position.x - collision.transform.position.x);
                    damage(collision.gameObject.GetComponentInParent<Draba_G>().ATK);
                    transform.Translate(v * T1, T2, 0);
                    rig.AddForce(new Vector2(v * F1, F2));
                    GM.HpUpdate();
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
        if (Physics2D.Raycast(new Vector2(transform.localPosition.x + 0.15f, transform.localPosition.y - 0.4f), Vector2.down, 0.05f, LayerMask.GetMask("Ground")) )
          
        {
            hit1 = Physics2D.Raycast(new Vector2(transform.localPosition.x + 0.15f, transform.localPosition.y - 0.4f), Vector2.down, 0.05f, LayerMask.GetMask("Ground"));


            //若目標具有"地面"或"弓箭"標籤的物件 則判定為在地上
            if (hit1.collider.tag == "Ground" || hit1.collider.tag == "Arrow" || hit1.collider.tag == "Platform")
            {
                On_GroundAll = true;
            }
            else
            {
                On_GroundAll = false;
            }
        }

        else if (Physics2D.Raycast(new Vector2(transform.localPosition.x - 0.1f, transform.localPosition.y - 0.4f), Vector2.down, 0.05f, LayerMask.GetMask("Ground")))
        {
            hit2 = Physics2D.Raycast(new Vector2(transform.localPosition.x - 0.1f, transform.localPosition.y - 0.4f), Vector2.down, 0.05f, LayerMask.GetMask("Ground"));
            if (hit2.collider.tag == "Ground" || hit2.collider.tag == "Arrow" || hit2.collider.tag == "Platform")
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
        GameOverScreen.alpha = 0;
        GameOverScreen.blocksRaycasts = false;
        GameOverScreen.interactable = false;
        Stop = false;
        CanBeHit = true;
        scene = SceneManager.GetActiveScene();
        SoundManager = FindObjectOfType<AudioSource>();
        print(scene.name);
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
        }
        
        if (PlayerPrefs.GetInt("Sword"+1)==0)
        {
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
        GM.Clear();
        Timer += Time.deltaTime;
        Timer2 += Time.deltaTime;
        Timer3 += Time.deltaTime;

        ani.SetFloat("DamageTimer", Timer2);
       

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

        // 圖示.繪製線條(起點,終點)
        Gizmos.DrawLine(transform.position, transform.position + transform.right * StopDistance);
    }

}
