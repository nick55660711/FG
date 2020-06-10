using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region 欄位
    public Player player1;
    public float HP_MAX;
    public Image HP_Bar;
    public float Crystal_No;
    public Text HpText;
    public Text CrystalText;



    [Header("進入的場景名稱")]
    public string SceneName;
    [Header("當前場景名稱")]
    public Scene SceneNow;
    




    #endregion

    #region 方法
    public void EnterMap()
    {
        if (Input.GetKeyDown("Up"))
        {
            SceneManager.LoadScene(SceneName);


        }
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneNow.name);

    }

    public void HpUpdate()
    {
        HpText.text = "Hp：" + player1.Hp;
        HP_Bar.fillAmount = player1.Hp / HP_MAX;
    }

    public void GetItem(GameObject item) 
    {
        Crystal_No += 1;
        CrystalText.text = " : " + Crystal_No ;

        // 編號為0的水晶沒有對話，直接摧毀
       
        if (item.GetComponent<Crystal>().ID == 0) 
        {
            Destroy(item);
        }
        
    }



    /*
    private void OnTriggerStay2D(Collider2D other)
    {
        
        print(Input.GetKeyDown("up"));
        print(other.tag);

        if (other.gameObject.tag == "Player" && Input.GetKeyDown("up") && gameObject.name == "Transport0")
        {
            player1.transform.position = Trans[1].transform.position;

        }

        if (other.gameObject.tag == "Player" && Input.GetKeyDown("up") && gameObject.name == "Transport1")
        {
            player1.transform.position = Trans[0].transform.position;

        }





    } 
   

    
    private void OnCollisionStay2D(Collision2D other)
    {
        print(Input.GetKeyDown("up"));
        print(other.gameObject.tag);

        if (other.gameObject.tag == "Player" && Input.GetKeyDown("up") && gameObject.name == "Transport0")
        {
            player1.transform.position = Trans[1].transform.position;

        }

        if (other.gameObject.tag == "Player" && Input.GetKeyDown("up") && gameObject.name == "Transport1")
        {
            player1.transform.position = Trans[0].transform.position;

        }




    }
    */

    #endregion

    #region 事件

    private void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        SceneNow = SceneManager.GetActiveScene() ;

        // enemy Layer不互相碰撞
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(8, 9);
        HP_MAX = player1.Hp;

    }



    private void Update()
    {
        if (Input.GetKeyDown("t")) { ReStart(); }
    }

    #endregion






}
