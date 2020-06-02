using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public Player player1;


    private void Update()
    {   

            transform.localPosition = new Vector3(player1.transform.localPosition.x, 0, -10);
        
    }



}
