using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Arrows_Hor : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().RecibirDanyo();
        }
        Destroy(this.gameObject);
    }

}
