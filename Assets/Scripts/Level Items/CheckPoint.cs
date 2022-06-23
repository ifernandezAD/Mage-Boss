using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    private bool isActive;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!isActive)
            {
                other.GetComponent<PlayerSoundManager>().PlayAudioCheckPoint();
                
                isActive = true;
                anim.SetBool("isActive", true);
            }

        }
    }
}
