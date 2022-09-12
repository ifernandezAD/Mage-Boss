using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceManager : MonoBehaviour
{

    private Rigidbody miRigid;
    public ParticleSystem hit;
 
  
    private float initialJumpSpeed;
    public float jumpForceFactor;

    private void Start()
    {
        miRigid = GetComponent<Rigidbody>();
        initialJumpSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().jumpSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        hit.Play();
        miRigid.constraints= RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        Destroy(this.gameObject, 10);

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce( Vector2.up *(initialJumpSpeed*jumpForceFactor));
       }
    }
}
