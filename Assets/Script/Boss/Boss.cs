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

    public Camera MC;
    public BoxCollider2D Wall;
    public BoxCollider2D Wall1;
    #endregion

    #region 方法
    bool Kill;
    public void damage(float ATK)
    {
        if (CanBeHit)
        {
            for (int i = 0; i < tmp_T.transform.childCount; i++)
            {
                tmp_T.transform.GetChild(i).GetComponent<Draba>().HIT();
            }

            Hp -= ATK;

            CanBeHit = false;




            StartCoroutine(Grow_T_Fall());
            if (Hp <= 0)
            {
                Kill = true;
                StartCoroutine(Grow_T_Fall());
                StartCoroutine(Grow_G_FALL());

            }
        }


    }

    public void dead()
    {

        Destroy(gameObject);

    }


    Transform POS;
    GameObject tmp_T;
    WaitForSeconds WAS = new WaitForSeconds(0.5f);
    /*
    IEnumerator Grow_T()
    {

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

            tmp_T.GetComponent<BoxCollider2D>().offset += new Vector2(0, 1) * 0.1f;
            tmp_T.GetComponent<SpriteRenderer>().size += new Vector2(0, 1) * 0.1f;
            yield return WAS3;
        }
        CanBeHit = true;
        StartCoroutine(Grow());
    }

    IEnumerator Grow_T_Fall()
    {

        while (tmp_T.GetComponent<SpriteRenderer>().size.y >0.1f)
        {
            tmp_T.GetComponent<SpriteRenderer>().size -= new Vector2(0, 1) * 0.1f;
            tmp_T.GetComponent<BoxCollider2D>().offset -= new Vector2(0, 1) * 0.1f;

            yield return WAS3;
        }
        Right = !Right;
        if (!Kill) StartCoroutine(Grow_T());
    }


    WaitForSeconds WAS2 = new WaitForSeconds(5);

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


    WaitForSeconds WAS3 = new WaitForSeconds(0.001f);




    IEnumerator Grow_G()
    {
        Wall.enabled = true;
        Wall1.enabled = true;

        while (Draba_T.size.y < 3)
        {
            Draba_T.size += new Vector2(0, 1) * 0.1f;
            Draba_T1.size += new Vector2(0, 1) * 0.1f;
            yield return WAS3;
        }

        while (Draba_G.size.x<52f)
        {
        Draba_G.size += new Vector2(1,0)*0.2f;
        Draba_G.GetComponent<BoxCollider2D>().offset -= new Vector2(1,0)*0.2f;
        yield return WAS3;
        }

        Wall.enabled = false;
        Wall1.enabled = false;
        StartCoroutine(Grow_T());
    }

    public GameObject Crystal;
    public Transform Crystal_T;
    IEnumerator Grow_G_FALL()
    {

        while (Draba_T.size.y > 0.1f)
        {
            Draba_T.size -= new Vector2(0, 1) * 0.1f;
            Draba_T1.size -= new Vector2(0, 1) * 0.1f;
            yield return WAS3;
        }
         
        Tower[0].GetComponent<BoxCollider2D>().enabled = false;
        Tower[1].GetComponent<BoxCollider2D>().enabled = false;

        while (Draba_G.size.x > 0.1f)
        {
            Draba_G.size -= new Vector2(1, 0) * 0.2f;
            Draba_G.GetComponent<BoxCollider2D>().offset += new Vector2(1, 0) * 0.2f;
            yield return WAS3;
        }

        Instantiate(Crystal, Crystal_T.position , Quaternion.identity);

        yield return WAS2;
        Destroy(gameObject);

    }







    #region 事件

    protected virtual void Start()
    {
        player1 = FindObjectOfType<Player>();
        
        Tower[0].GetComponent<BoxCollider2D>().enabled = true;
        Tower[1].GetComponent<BoxCollider2D>().enabled = true;
        Right = true;
        StartCoroutine(Grow_G());

    }

  
    protected virtual void Update()
    {
       

    }



    #endregion




}
