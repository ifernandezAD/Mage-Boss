using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacionSalaMartillo : MonoBehaviour
{
    public Spawn_arrows[] arrowSpawners;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < arrowSpawners.Length; i++)
            {
                arrowSpawners[i].enabled = true;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < arrowSpawners.Length; i++)
            {
                arrowSpawners[i].enabled = false;
            }
        }
    }
}
