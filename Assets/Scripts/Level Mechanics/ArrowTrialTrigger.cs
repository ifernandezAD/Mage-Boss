using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrialTrigger : MonoBehaviour
{
    public ArrowShootMage arrowShootMage;


    private void OnTriggerEnter(Collider other)
    {
         if (arrowShootMage != null)
        {
            arrowShootMage.enabled = true;
        }
       
    }
}
