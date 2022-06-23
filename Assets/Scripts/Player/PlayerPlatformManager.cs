using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformManager : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Adherente"))
        {
            transform.SetParent(other.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        transform.SetParent(null);
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Adherente"))
    //    {
    //        transform.SetParent(collision.transform);
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    transform.SetParent(null);
    //}
}
