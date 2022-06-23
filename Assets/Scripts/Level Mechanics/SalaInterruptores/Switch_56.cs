using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_56 : MonoBehaviour
{
    public GameObject platform;
    public bool active = false;
    public Animator myAnimator;

    private void OnCollisionEnter(Collision other)
    {
        myAnimator.SetTrigger("isPressed");

        if (other.gameObject.tag == "Player" && active == false)
        {
            platform.SetActive(true);
            active = true;
        }

        else if (other.gameObject.tag == "Player" && active == true)
        {
            platform.SetActive(false);
            active = false;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        myAnimator.SetTrigger("notPressed");
    }
}
