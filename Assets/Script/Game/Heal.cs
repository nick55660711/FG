using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public Player player1;
    GameManager GM;






    public void heal()
    {
        player1.HP = GM.HP_MAX;
        GM.HpUpdate();

    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) heal();
    }




    private void Start()
    {

        player1 = FindObjectOfType<Player>();
        GM = FindObjectOfType<GameManager>();

    }

}
