using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrialStop : MonoBehaviour
{
    public GameObject mage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Destroy(mage);
        }

    }
}
