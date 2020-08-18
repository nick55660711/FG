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
    public bool Fight;
    public bool CanBeHit;
    public bool Right;
    [Header("受傷計時器")]
    public float Timer2;
    //public Animator ani;
    /// <summary>
    /// Draba[0] 塔藤蔓
    /// </summary>
    public GameObject[] Draba;
    public GameObject[] Tower;
    public SpriteRenderer Draba_G;
    public SpriteRenderer Draba_T;
    public SpriteRenderer Draba_T1;

    public CameraControll MC;
    public BoxCollider2D Wall;
    public BoxCollider2D Wall1;

    public delegate void KillDelegate();
    public  KillDelegate OnKill;
    #endregion

    #region 方法
    bool Kill;
    public void damage(float ATK)
    {
        if (CanBeHit)
        {
            for (int i = 0; i < tmp_T.transform.childCount; i++)
            {
                tmp_T.transform.GetChild(i).GetComponent<Draba>().Burn();
            }

            Hp -= ATK;

            CanBeHit = false;




            if (Hp <= 0)
            {
                Kill = true;
                StopAllCoroutines();
                StartCoroutine(Grow_T_Fall());

            }
            else
            {
            StartCoroutine(Grow_T_Fall());
            }
        }


    }




   


    GameObject tmp_T;
    /*
    IEnumerator Grow_T()
    {
    Transform POS;
    WaitForSeconds WAS = new WaitForSeconds(0.5f);

        if (Right) POS = Tower[1].transform.GetChild(0);
        else POS = Tower[0].transform.GetChild(0);
        GameObject tmp1 = Instantiate(Draba[0], POS.position, Quaternion.identity);
        tmp1.transform.SetParent(transform);
        tmp_T = tmp1;
        while (tmp1.GetComponent<SpriteRenderer>().size.y < 5.5f)
        {
            tmp1.GetComponent<SpriteRenderer>().size += new Vector2(0, 1) * 0.1f;

            yield return WAS3;
        }
        CanBeHit = true;
    }
    */
    public GameObject Draba_TB_R;
    public GameObject Draba_TB_L;
    IEnumerator Grow_T()
    {
        SoundEffect.Play();
        float V = 1;
        MC.SetON = true;

        if (Right)
        {
            tmp_T = Draba_TB_R;
        }

        if (!Right)
        {
            tmp_T = Draba_TB_L;

        }
        while (tmp_T.GetComponent<SpriteRenderer>().size.y < 5.5f)
        {

           
                if (MC.transform.position.y > 5f) V = -1;
                if (MC.transform.position.y < 4.36f) V = 1;
                MC.transform.Translate(new Vector2(0, 1) * V * 0.04f);
             
            
            tmp_T.GetComponent<BoxCollider2D>().offset += new Vector2(0, 1) * 0.05f;
            tmp_T.GetComponent<SpriteRenderer>().size += new Vector2(0, 1) * 0.05f;
            yield return WAS3;
        }
        player1.Stop = false;
        CanBeHit = true;
        MC.SetON = false;
        SoundEffect.Stop();
        StartCoroutine(Grow());
    }

    public GameObject[] Torch = new GameObject[5];
    int ID = 0;
    IEnumerator Grow_T_Fall()
    {

        while (tmp_T.GetComponent<SpriteRenderer>().size.y >0.1f)
        {
            tmp_T.GetComponent<SpriteRenderer>().size -= new Vector2(0, 1) * 0.1f;
            tmp_T.GetComponent<BoxCollider2D>().offset -= new Vector2(0, 1) * 0.1f;

            yield return WAS3;
        }
        Right = !Right;
            Vector2 RandomPox = new Vector2(Torch[ID].transform.position.x, -2);
            GameObject tmp = Instantiate(Draba[2], RandomPox, Quaternion.Euler(0, 0, 0));

        if (!Kill) {
            ID++;
            Torch[ID].GetComponent<Torch>().FireUP();
            WaitForSeconds WAS2 = new WaitForSeconds(5-ID/2);
            GetComponent<Boss_V>().Overdrive();
            StartCoroutine(Grow_T());
        }
        else
        {
            GetComponent<Boss_V>().enabled = false;
            Draba_G.GetComponent<BoxCollider2D>().isTrigger = false;
            StartCoroutine(Grow_G_FALL());
        }
    }

 
    WaitForSeconds WAS2 = new WaitForSeconds(4);
    WaitForSeconds WAS3 = new WaitForSeconds(0.00003f);
    WaitForSeconds WAS4 = new WaitForSeconds(0.1f);


    IEnumerator Grow()
    {


        while (CanBeHit) {
            yield return WAS2;

            Vector2 MaxValue = tmp_T.GetComponent<Collider2D>().bounds.max;
            Vector2 MinValue = tmp_T.GetComponent<Collider2D>().bounds.min;
            float A = 0;
            float B = 0;
            if (Right)
            {
                A = MaxValue.x -0.6f;
                B = 90;
            }
            if (!Right)
            {
                A = MinValue.x+0.6f;
                B = -90;
            }

            Vector2 RandomPox = new Vector2(A, Random.Range(MinValue.y, MaxValue.y));
           GameObject tmp = Instantiate(Draba[1], RandomPox, Quaternion.Euler(0, 0, B));
            tmp.transform.SetParent(tmp_T.transform);


        }
    }

    #endregion



    public AudioClip EarthQuake;


    IEnumerator Grow_G()
    {
        Wall.enabled = true;
        Wall1.enabled = true;
        player1.Stop = true;
        float V = 1;
        MC.SetON = true;

        int T = 0;
            SoundEffect.Play();
        while (T <100)
        {
            if (MC.transform.position.y > 5f) V = -1;
            if (MC.transform.position.y < 4.36f) V = 1;
            MC.transform.Translate(new Vector2(0, 1) * V * 0.09f);
            T++;

            yield return WAS3;
        }

        while (Draba_T.size.y < 3)
        {
            Draba_T.size += new Vector2(0, 1) * 0.1f;
            Draba_T1.size += new Vector2(0, 1) * 0.1f;
            if (MC.transform.position.y > 5f) V = -1;
            if (MC.transform.position.y < 4.36f) V = 1;
            MC.transform.Translate(new Vector2(0, 1) * V * 0.07f);
            yield return WAS3;
        }

        if (player1.transform.position.y < 1.2f)
        {
            player1.rig.AddForce(new Vector2(0, 600));
        }

        while (Draba_G.size.x < 52f)
        {
            

            if (MC.transform.position.y > 5f) V = -1;
            if (MC.transform.position.y < 4.36f) V = 1;
            MC.transform.Translate(new Vector2(0, 1) * V * 0.05f);
            Draba_G.size += new Vector2(1, 0) * 0.2f;
            Draba_G.GetComponent<BoxCollider2D>().offset -= new Vector2(1, 0) * 0.2f;
            yield return WAS3;
        }

        Wall.enabled = false;
        Wall1.enabled = false;
       
      
        Torch[0].GetComponent<Torch>().FireUP();
        GetComponent<Boss_V>().enabled = true;
        StartCoroutine(Grow_T());
        
    }

    public GameObject Crystal;
    public GameObject Step;
    public Transform Crystal_T;

    public SpriteRenderer Draba_B;

    public SpriteRenderer Draba_G_fire;

    public Animator Draba_back_fire; //高度 7.22f
    IEnumerator Grow_G_FALL()
    {
        yield return new WaitForSeconds(1.2f);
        Draba_back_fire.SetTrigger("Burn");
        Draba_G.GetComponent<Animator>().SetTrigger("Burn");
        SoundEffect.Play();
        int V = 1;
        MC.SetON = true;

        while (Draba_G_fire.size.x < 52f)
        {


            if (MC.transform.position.y > 5f) V = -1;
            if (MC.transform.position.y < 4.36f) V = 1;
            MC.transform.Translate(new Vector2(0, 1) * V * 0.05f);
            yield return WAS3;
        }
        Destroy(Draba_G.gameObject);
        /*
        while (Draba_G.size.x > 0.1f)
        {

            if (MC.transform.position.y > 5f) V = -1;
            if (MC.transform.position.y < 4.36f) V = 1;
            MC.transform.Translate(new Vector2(0, 1) * V * 0.04f);
            Draba_G.size -= new Vector2(1, 0) * 0.2f;
            Draba_G.GetComponent<BoxCollider2D>().offset += new Vector2(1, 0) * 0.2f;
            yield return WAS3;
        }
        */
        MC.SetON = false;

        while (Draba_T.size.y > 0.1f)
        {
            Draba_T.size -= new Vector2(0, 1) * 0.1f;
            Draba_T1.size -= new Vector2(0, 1) * 0.1f;
            yield return WAS3;
        }
        while (SoundManager.volume>0)
        {

            SoundManager.volume -= 0.05f;
            yield return WAS4;
        }

        Tower[0].GetComponent<BoxCollider2D>().enabled = false;
        Tower[1].GetComponent<BoxCollider2D>().enabled = false;
        SoundManager.Stop();
        SoundEffect.Stop();
        yield return WAS2;
        Destroy(Draba_TB_R);
        Destroy(Draba_TB_L);
        Destroy(Draba_T.gameObject);
        Destroy(Draba_T1.gameObject);
        Destroy(Draba_B.gameObject);
        // Instantiate(Crystal, Crystal_T.position , Quaternion.identity);
        //Step.SetActive(true);
        // Crystal.transform.position = Crystal_T.position;

        Destroy(gameObject);

    }




    public AudioSource SoundManager;
    public AudioSource SoundEffect;


    #region 事件

    protected virtual void Start()
    {
        player1 = FindObjectOfType<Player>();
        SoundManager = FindObjectOfType<AudioSource>();
        Tower[0].GetComponent<BoxCollider2D>().enabled = true;
        Tower[1].GetComponent<BoxCollider2D>().enabled = true;
        Right = true;

        SoundEffect = Instantiate(SoundManager);
        SoundEffect.clip = EarthQuake;
        SoundEffect.Stop();
        StartCoroutine(Grow_G());
    }

  
    protected virtual void Update()
    {
       

    }



    #endregion




}
