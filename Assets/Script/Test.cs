using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    [Header("當前場景名稱")]
    public Scene SceneNow;
    GameManager GM;
    private void Start()
    {   
        rig = GetComponent<Rigidbody2D>();
       
    }
    Rigidbody2D rig;
    bool Nogravity;


    void Update()
    {
        

        if (Input.GetKey("r")) 
        {
            rig.AddForce(Vector2.up*50);
        }
        

        if (Input.GetKeyDown("e"))
        {
            GetComponent<Player>().HP = 100;
            GetComponent<Player>().GetBow = true;
            GetComponent<Player>().GetSword = true;
            FindObjectOfType<GameManager>().HpUpdate();
        }
        
       


    }



}
