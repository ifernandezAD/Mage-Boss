using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacionSalaObstaculos : MonoBehaviour
{
    public TwoPointsMover[] twoPointsMoveScripts;
    public Crusher[] crusherScripts;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i= 0; i < twoPointsMoveScripts.Length; i++)
            {
                twoPointsMoveScripts[i].enabled = true;
            }
            for (int i= 0; i < crusherScripts.Length; i++)
            {
                crusherScripts[i].enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < twoPointsMoveScripts.Length; i++)
            {
                twoPointsMoveScripts[i].enabled = false;
            }
            for (int i = 0; i < crusherScripts.Length; i++)
            {
                crusherScripts[i].enabled = false;
            }
        }
    }
}


