using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShootMage : MonoBehaviour
{
    //Variables del disparo
    public float arrowSpeed;
    public Transform[] arrowSpawn;
    public Rigidbody[] arrowPrefab;
    Rigidbody clone;

    //Variables de la corrutina
    public bool trialActive;
    public float seconds;

    void Start() {StartCoroutine("MageShooting");}

    IEnumerator MageShooting()
    {
        while (trialActive == true)
        {
            for (int i = 0; i < 3; i++)
            {
             yield return new WaitForSeconds(seconds);
             Shoot();
            }
         
            yield return new WaitForSeconds(seconds+2.5f);
            GiantShoot();
            yield return new WaitForSeconds(seconds);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    void Shoot()
    {
        clone = Instantiate(arrowPrefab[0], arrowSpawn[Random.Range(0,2)].position, arrowSpawn[Random.Range(0, 2)].rotation) as Rigidbody;
        clone.AddForce(arrowSpawn[Random.Range(0, 2)].transform.right * arrowSpeed);
        //Destroy(arrowPrefab, 5);
    }

    void GiantShoot()
    {
        clone = Instantiate(arrowPrefab[1], arrowSpawn[2].position, arrowSpawn[2].rotation) as Rigidbody;
        clone.AddForce(arrowSpawn[2].transform.right * arrowSpeed);
        //Destroy(arrowPrefab, 5);
    }
}
