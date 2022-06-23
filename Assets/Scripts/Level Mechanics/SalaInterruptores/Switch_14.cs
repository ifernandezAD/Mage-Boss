using UnityEngine;

public class Switch_14 : MonoBehaviour
{
    public bool active = false;
    public TwoPointsMover twoPointsMover;
    public Animator myAnimator;

    private void OnCollisionEnter(Collision other)
    {
        myAnimator.SetTrigger("isPressed");

        if (other.gameObject.tag == "Player" && active == false)
        {
            twoPointsMover.enabled = true;
            active = true;
        }

        else if (other.gameObject.tag == "Player" && active == true)
        {
            twoPointsMover.enabled = false;
            active = false;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        myAnimator.SetTrigger("notPressed");
    }
}
