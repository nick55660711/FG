using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrabaTrigger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           StartCoroutine( GetComponentInParent<Draba_S>().Grow_G());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponentInParent<Draba_S>().Fall();
        }
    }


}
