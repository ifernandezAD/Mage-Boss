using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacionSalaDiana : MonoBehaviour
{

    public Rotation_Fireball rotationFireball;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rotationFireball.enabled = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            rotationFireball.enabled = false;
            
        }
    }
}
