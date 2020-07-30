using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Map0_Load : MonoBehaviour
{
    public CanvasGroup DialogueScreen;
    public GameManager GM;
    public Save GMSave;
    Scene scene;
    public Player player1;
    public GameObject Trans0;
    public Transform boundary1;
    public Transform boundary2;



    



    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
        GMSave = FindObjectOfType<Save>();
        player1 = FindObjectOfType<Player>();
        DialogueScreen = GameObject.Find("DialogueScreen").GetComponent<CanvasGroup>();
        scene = SceneManager.GetActiveScene();
        if(scene.name != "Map0")
        {
            this.enabled = false;
        }
        
        /*
        switch (PlayerPrefs.GetInt("Map0PlayerLocate"))
        {
            case 0:
                break;

            case 1:
                player1.transform.position = boundary1.position ;
                break;

            case 2:
                player1.transform.position = boundary2.position ;
                break;

        }


    */

    }


   




}
