using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_3 : MonoBehaviour
{
    public GameObject particle;
    public bool active = false;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && active == false)
        {
            particle.SetActive(true);
            active = true;
        }

        else if (other.gameObject.tag == "Player" && active == true)
        {
            particle.SetActive(false);
            active = false;
        }
    }
}
