using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSign : MonoBehaviour
{

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerSoundManager>().PlayAudioMessage();
            animator.SetBool("infoDisplayed", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("infoDisplayed", false);
        }
    }
}
