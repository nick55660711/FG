using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public Transform Spawn1;
    public bool SpwanON;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!SpwanON && other.tag == "Player")
        {
            createEnemy();
            SpwanON = true;
        }
        
    }
    


    public void createEnemy()
    {
        Instantiate(Enemy, Spawn1.position, Spawn1.rotation);

    }









}
