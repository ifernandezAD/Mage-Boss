using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    float xInitPosPlayer;
    float xInitPosCamera;
    float xCurrentPosPlayer;
    public float xOffset;

    private float heightFromPlayer;
    void Start()
    {
        this.transform.SetParent(null);

        xInitPosPlayer = target.transform.position.x;
        xInitPosCamera = xInitPosPlayer;
        heightFromPlayer = transform.position.y - target.transform.position.y;

        transform.position = new Vector3(
            xInitPosCamera + xOffset,
            target.transform.position.y + heightFromPlayer,
            transform.position.z);

    }

    void Update()
    {
        xCurrentPosPlayer = target.transform.position.x;
        xOffset = xCurrentPosPlayer - xInitPosPlayer;
        transform.position = new Vector3(
            xInitPosCamera + xOffset,
            target.transform.position.y + heightFromPlayer,
            transform.position.z);
    }
}
