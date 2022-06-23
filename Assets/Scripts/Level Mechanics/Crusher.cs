using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    public float upspeed;
    public float downspeed;
    public Transform up;
    public Transform down;
    bool goingDown;

    private float crusherHeight;


    // Update is called once per frame
    void Update()
    {
        if (transform.position.y>= up.position.y )
        {
            goingDown = true;
        }

        if (transform.position.y<= down.position.y)
        {
            goingDown = false;
        }

        if (goingDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, down.position ,downspeed*Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, up.position , upspeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().RecibirDanyo();
        }
    }

}
