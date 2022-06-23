using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallShoot : MonoBehaviour
{

    public Transform fireBallSpawn;
    public Rigidbody arrowPrefab;
    public float arrowSpeed = 25.0f;

    Rigidbody clone;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ArrowPlayer")
        {
            clone = Instantiate(arrowPrefab, fireBallSpawn.position, fireBallSpawn.rotation) as Rigidbody;
            clone.AddForce(-fireBallSpawn.transform.right * arrowSpeed);
        }
    }

}
