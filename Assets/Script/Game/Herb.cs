using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herb : MonoBehaviour, ICollect
{

    public Player player1;
    GameManager GM;

    public void Get()
    {
            GM.GetItem(1);

            Destroy(gameObject);


    }

    private void Start()
    {

        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        GM = FindObjectOfType<GameManager>();

    }

}
