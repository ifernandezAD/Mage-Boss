using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianaSalaCajas : MonoBehaviour
{
    public GameObject barrier;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        audioSource.Play();
        Destroy(barrier);  
    }
}
