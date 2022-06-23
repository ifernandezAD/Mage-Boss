using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacionSalaArco : MonoBehaviour
{
    public ArrowShootMage scriptMago;

    private void Start()
    {
        scriptMago.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && scriptMago!=null)
        {
            
            scriptMago.enabled = true;            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && scriptMago!=null)
        {
            scriptMago.enabled = false;
            scriptMago.trialActive = false;
            StopAllCoroutines();
        }

    }

}
