using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjust : MonoBehaviour
{
    // Start is called before the first frame update
   public void playerDamage(float damage)
    {
        
        character_mov playerBody = transform.GetComponentInChildren<character_mov>();
        if (playerBody != null)
        {
         
            playerBody.playerHitDamage(damage);

        }
    }
    public void playerScore()
    {

        character_mov playerBody = transform.GetComponentInChildren<character_mov>();
        NewBehaviourScript rif = transform.GetComponentInChildren<NewBehaviourScript>();
        if (rif != null)
        {
            rif.increaseMag();
        }
       
        if (playerBody != null)
        {

            playerBody.playerScoreE();
            

        }
       
    }
}
