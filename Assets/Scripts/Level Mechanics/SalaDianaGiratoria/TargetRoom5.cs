using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRoom5 : MonoBehaviour
{

    public GameObject destroyableBarrier;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ArrowPlayer")
        {
            audioSource.Play();
            Destroy(destroyableBarrier);
        }
    }
}
