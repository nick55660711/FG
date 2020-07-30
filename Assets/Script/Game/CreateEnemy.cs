using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public Transform[] Spawn;
    public bool SpawnON;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!SpawnON && other.tag == "Player")
        {
            createEnemy(Spawn);
            SpawnON = true;
        }
        
    }
    


    public void createEnemy(Transform[] collider)
    {
        for (int i = 1; i < Spawn.Length ; i++)
        {

        Instantiate(Enemy, collider[i].position, Quaternion.identity);
        }

    }

    private void Start()
    {
        Spawn = GetComponentsInChildren<Transform>();
    }







}
