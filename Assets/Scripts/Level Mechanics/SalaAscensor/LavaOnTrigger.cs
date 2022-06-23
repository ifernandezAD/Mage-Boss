using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaOnTrigger : MonoBehaviour
{
    public GameObject lava;
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            lava.SetActive(true);
            lava.GetComponent<LavaRising>().isActive = true;
            door.SetActive(true);
        }
    }
}
