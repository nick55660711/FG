using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crystal : MonoBehaviour
{
    #region 欄位
    public int ID;
    
    public Player player1;
    



    #endregion

    #region 方法

  


   

   



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
