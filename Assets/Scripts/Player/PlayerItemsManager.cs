using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItemsManager : MonoBehaviour
{

    public float arrowSpeed = 18.0f;
    public float lanceSpeed = 40f;
    public Transform arrowSpawn;
    public Transform lanceSpawn;
    public Rigidbody arrowPrefab;
    public Rigidbody lancePrefab;
    public GameObject bow;

    Rigidbody clone;

    public float appleCadency = 0.8f;
    private bool canShootApple = true;
    public float appleDelay;
    public float lanceCadency = 1f;
    private bool canShootLance = true;
    public float spearDelay;

    public CameraShake cameraShake;

    private PlayerSoundManager psm;
    private Animator animator;

    private void Start()
    {
        psm = GetComponent<PlayerSoundManager>();
        animator = GetComponentInChildren<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (canShootApple)
            {
                StartCoroutine("ThrowApple");
            }

        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (canShootLance)
            {
                StartCoroutine("ThrowSpear");
            }
        }
    }

    IEnumerator ThrowSpear()
    {   
        animator.SetTrigger("Spear");
        canShootLance = false;
        yield return new WaitForSeconds(spearDelay);      
        clone = Instantiate(lancePrefab, lanceSpawn.position, lanceSpawn.rotation) as Rigidbody;
        clone.AddForce(arrowSpawn.transform.right * arrowSpeed);
        psm.PlayAudioFire();
        yield return new WaitForSeconds(lanceCadency);
        canShootLance = true;
    }

    IEnumerator ThrowApple()
    {
        animator.SetTrigger("Apple");
        canShootApple = false;
        yield return new WaitForSeconds(appleDelay);
        clone = Instantiate(arrowPrefab, arrowSpawn.position, arrowSpawn.rotation) as Rigidbody;
        clone.AddForce(arrowSpawn.transform.right * arrowSpeed);
        psm.PlayAudioFire();       
        yield return new WaitForSeconds(appleCadency);
        canShootApple = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Destroy_Wall" && Input.GetKey(KeyCode.J))
        {

            StartCoroutine(cameraShake.CameraShaking());

            psm.PlayAudioBreakWall();

            Destroy(other.gameObject);
        }
    }
}
