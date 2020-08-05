using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draba_G : MonoBehaviour
{
    public Player player1;
    public float ATK;
    public Boss B;
    public bool GetHit;
    public virtual void HIT()
    {
    
    }
    public virtual void Burn()
    {
        print("A");
    }
}
