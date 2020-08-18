using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamera : MonoBehaviour
{
    CameraControll camera1;
    
    private void Start()
    {
        camera1 = FindObjectOfType<CameraControll>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            camera1.CameraSet(transform.position.y);
        }

    } 
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            camera1.CameraSet(transform.position.y);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            camera1.CameraSet(0);
        }
    }
}
