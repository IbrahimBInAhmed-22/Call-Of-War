using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objects : MonoBehaviour
{
    public float objectHealth = 100f;
    public void objectHitDamage(float amount)
    {
        objectHealth -= amount;
        if(objectHealth < 0 )
        {
             die();
        }
    }
    void die()
    {
        Destroy(gameObject);
    }
}
