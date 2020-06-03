using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region 欄位
    public Player player1;

    [Header("進入的場景名稱")]
    public string SceneName;

    


    #endregion

    #region 方法
    public void EnterMap()
    {
        if (Input.GetKeyDown("Up"))
        {
            SceneManager.LoadScene(SceneName);


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
    }



    private void Update()
    {
       
    }

    #endregion






}
