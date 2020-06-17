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



    
    
    




    #endregion

    #region 方法
    public void ChangeScene(string SceneName)
    {
        PlayerPrefs.SetFloat("HP",player1.HP);
        PlayerPrefs.SetFloat("Crystal_No", Crystal_No);
        SceneManager.LoadScene(SceneName);


    }




    

    public void HpUpdate()
    {
        HpText.text = "Hp : " + player1.HP;
        HP_Bar.fillAmount = player1.HP / HP_MAX;
    }

    public void GetItem(GameObject item) 
    {

        // 編號為0的水晶沒有對話，直接摧毀
       
        if (item.GetComponent<Crystal>().ID == 0) 
        {
            Destroy(item);
        }

       
        player1.HP += 5;
        player1.HP = Mathf.Clamp(player1.HP , 0 , HP_MAX);



        HpUpdate();
        Crystal_No += 1;
        CrystalText.text = " : " + Crystal_No ;
    
    }

    



    

    #endregion

    #region 事件

    private void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        HP_Bar = GameObject.Find("HP_Bar").GetComponent<Image>();
        HpText = GameObject.Find("HP_Text").GetComponent<Text>();
        CrystalText = GameObject.Find("Crystal_No_Text").GetComponent<Text>();



        player1.HP = PlayerPrefs.GetFloat("HP");
        Crystal_No = PlayerPrefs.GetFloat("Crystal_No");


        // enemy Layer不互相碰撞
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(8, 9);

        HpText.text = "Hp : " + player1.HP;
        HP_Bar.fillAmount = player1.HP / HP_MAX;
        CrystalText.text = " : " + Crystal_No;



    }



   

    #endregion






}
