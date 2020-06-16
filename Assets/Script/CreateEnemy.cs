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
            createEnemy(other.transform);
            SpwanON = true;
        }
        
    }
    


    public void createEnemy(Transform collider)
    {
        Instantiate(Enemy, collider.position, Quaternion.identity);

    }









}
