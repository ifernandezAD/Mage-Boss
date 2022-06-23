using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRising : MonoBehaviour
{
    public float speed;
    public bool isActive;    

    public Vector3 origin;
    public GameObject door;

    void Start()
    {
        origin = this.transform.position;
    }


    void Update()
    {
        if (isActive)
        {
            this.transform.Translate(0, speed * Time.deltaTime, 0);
        }
        else if (isActive==false)
        {
            this.transform.position = origin;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().Morir();
        }
    }

    public void ResetLava()
    {
        StartCoroutine("ReiniciarLava");

    }

    IEnumerator ReiniciarLava()
    {

        yield return new WaitForSeconds(1.2f);
        isActive = false;
        this.gameObject.SetActive(false);
        transform.position = origin;
        door.SetActive(false);
    }
}
