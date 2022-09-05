using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 4.0f;
    public float moveDirection;
    public bool facingRight = true;
    private Rigidbody rigidbody;
    public float jumpSpeed = 600.0f;
    public float fallMultiplier;

    public bool grounded = false;
    private bool enSuelo;


    private PlayerSoundManager psm;
    private Animator animator;

    public static event Action jumping;
    public static event Action onGround;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        psm = GetComponent<PlayerSoundManager>();

    }
 
    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");

        rigidbody.velocity = new Vector2(moveDirection*maxSpeed, rigidbody.velocity.y);

        if (moveDirection>0.0f && !facingRight)
        {
            Flip();
        }else if (moveDirection<0.0f && facingRight)
        {
            Flip();
        }

        grounded = false;

        RaycastHit resultRay;
        if (Physics.Raycast(transform.position, Vector3.down, out resultRay, 1.5f))
        {
            if (resultRay.transform.tag == "Suelo" || resultRay.transform.tag == "Adherente" || resultRay.transform.tag=="LancePrefab" || resultRay.transform.tag =="Spike")
            {
                grounded = true;
                onGround?.Invoke();
               
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }

    }

    private void FixedUpdate()
    {
        if (grounded)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveDirection));
        }

        if(rigidbody.velocity.y < 0)
        {
            rigidbody.velocity+=Vector3.up*Physics.gravity.y*fallMultiplier*Time.deltaTime;
        }

    }

    private void Saltar()
    {
        if (Mathf.Abs(rigidbody.velocity.y)<0.01f || grounded)
        {
            animator.SetTrigger("Jumping");          
            rigidbody.AddForce(new Vector2(0, jumpSpeed));
            psm.PlayAudioJump();
            jumping?.Invoke();
        }
    }

    void Flip()
    {
         facingRight = !facingRight;
         transform.Rotate(Vector3.up, 180.0f, Space.World);
    }      
}
