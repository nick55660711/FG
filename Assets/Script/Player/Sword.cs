using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Animator ani;
    Collider2D Cod;
    int Atk =25;


    public void Slash()
    {
        Cod.enabled = true;
        ani.SetTrigger("Slash");
    }

    public void Slashover()
    {

        Cod.enabled = false;
    }
   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) collision.GetComponent<Enemy>().damage(Atk); ;

        if (collision.CompareTag("Box"))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(transform.right * 4000);
        }
    }


    private void Start()
    {
        ani= GetComponent<Animator>();
        Cod = GetComponent<BoxCollider2D>();
    
    
    }
}
