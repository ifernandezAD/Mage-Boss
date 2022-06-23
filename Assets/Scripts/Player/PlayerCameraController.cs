using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject arcTestZone;
    public GameObject switchesZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TargetArcZone")
        {
            mainCamera.SetActive(false);
            arcTestZone.SetActive(true);
        }

        if (other.gameObject.name == "SwitchesZone")
        {
            mainCamera.SetActive(false);
            switchesZone.SetActive(true);
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "TargetArcZone")
        {
            mainCamera.SetActive(true);
            arcTestZone.SetActive(false);
        }

        if (other.gameObject.name == "SwitchesZone")
        {
            mainCamera.SetActive(true);
            switchesZone.SetActive(false);
        }
    }
}
