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
        GMSave = GM.GetComponent<Save>();
        player1 = FindObjectOfType<Player>();
        DialogueScreen = GameObject.Find("DialogueScreen").GetComponent<CanvasGroup>();
        scene = SceneManager.GetActiveScene();

        if (GMSave.Map0SaveResult[1] == 1)
        {
            DialogueScreen.GetComponentsInChildren<Text>()[1].gameObject.SetActive(false);
        }

        if (GMSave.Map0SaveResult[2] == 1) 
        {
            Trans0.GetComponent<Trans>().enabled = true;
        }

        if (GMSave.Map0SaveResult[3] == 1)
        {
            player1.GetBow = true;
        }

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




    }


   




}
