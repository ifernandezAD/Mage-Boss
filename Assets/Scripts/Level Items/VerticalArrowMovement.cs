using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalArrowMovement : MonoBehaviour
{
    public float vel = 35;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, vel * Time.deltaTime, 0, Space.World);
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
