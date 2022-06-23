using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowTarget : MonoBehaviour
{

    public GameObject elevadorContenedor;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ArrowPlayer")
        {
            elevadorContenedor.GetComponent<TwoPointsMover>().enabled = true;
        }
    }
}
