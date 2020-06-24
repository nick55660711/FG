using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public Player player1;
    private float X;
    private float Y;
    public bool SetON;




    public void CameraSet (int Y)
    {

        transform.position = new Vector3(player1.transform.position.x, Y, -10);
        SetON = true;

    }

    public void CancelSet()
    {

        SetON = false;

    }

    private void Start()
    {

        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    private void Update()
    {



        if (!SetON)
        {
            if (player1.transform.position.y > 6.5f)
            {
                Y = player1.transform.position.y - 2f;
            }

            else if (player1.transform.position.y < 5.5f)
            {
                Y = 4.5f;
            }


            transform.position = new Vector3(player1.transform.position.x, Y, -10);
        }



    }

   


}
