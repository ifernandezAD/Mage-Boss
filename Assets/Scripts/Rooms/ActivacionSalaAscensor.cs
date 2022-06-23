using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacionSalaAscensor : MonoBehaviour
{
    public TwoPointsMover[] sawMovements;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < sawMovements.Length; i++)
            {
                sawMovements[i].enabled = true;
            }
        }
    }
}
