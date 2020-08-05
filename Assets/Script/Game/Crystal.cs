using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crystal : MonoBehaviour , ICollect
{
    #region 欄位
    public int ID;
    
    public Player player1;
    GameManager GM;




    #endregion

    #region 方法




    public void Get()
    {
        
        GM.GetItem(0);

        // 編號為0的水晶沒有對話，直接摧毀
        if (ID == 0)
        {
            Destroy(gameObject);
        }

    }







    #endregion

    #region 事件
    private void Start()
    {

        player1 = FindObjectOfType<Player>();
        GM = FindObjectOfType<GameManager>();

    }
  

    #endregion




}
