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

    public Image bowImage;
    public Image hammerImage;
    public Image lanceImage;

    Rigidbody clone;
    public bool hasBow;
    public bool hasHammer;
    public bool hasLance;

    public float arrowCadency = 0.8f;
    private bool canShootArrow = true;
    public float lanceCadency = 1f;
    private bool canShootLance = true;

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
        if (Input.GetKeyDown(KeyCode.K) && hasBow)
        {
            if (canShootArrow)
            {
                animator.SetTrigger("isAttacking");
                ShootArrow();
                StartCoroutine("BowCadency");
            }

        }

        if (Input.GetKeyDown(KeyCode.L) && hasLance)
        {
            if (canShootLance)
            {
                ShootLance();
                StartCoroutine("LanceCadency");
            }

        }
    }

    IEnumerator BowCadency()
    {
        canShootArrow = false;
        yield return new WaitForSeconds(arrowCadency);
        canShootArrow = true;
    }

    IEnumerator LanceCadency()
    {
        canShootLance = false;
        yield return new WaitForSeconds(lanceCadency);
        canShootLance = true;
    }

    
    void ShootLance()
    {
        clone = Instantiate(lancePrefab, lanceSpawn.position, lanceSpawn.rotation) as Rigidbody;
        clone.AddForce(arrowSpawn.transform.right * arrowSpeed);
        psm.PlayAudioFire();
    }

    //Void_Shoot
    void ShootArrow()
    {
        clone = Instantiate(arrowPrefab, arrowSpawn.position, arrowSpawn.rotation) as Rigidbody;
        clone.AddForce(arrowSpawn.transform.right * arrowSpeed);
        psm.PlayAudioFire();
       //Destroy(arrowPrefab, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bow")
        {
            psm.PlayAudioItem();
            Destroy(collision.gameObject);
            hasBow = true;
            bowImage.gameObject.SetActive(true);
        }

        if (collision.gameObject.tag == "Hammer")
        {
            psm.PlayAudioItem();
            Destroy(collision.gameObject);
            hasHammer = true;
            hammerImage.gameObject.SetActive(true);
        }

        if (collision.gameObject.tag == "Lance")
        {
            psm.PlayAudioItem();
            Destroy(collision.gameObject);
            hasLance = true;
            lanceImage.gameObject.SetActive(true);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Destroy_Wall" && hasHammer && Input.GetKey(KeyCode.J))
        {

            StartCoroutine(cameraShake.CameraShaking());

            psm.PlayAudioBreakWall();

            Destroy(other.gameObject);
        }
    }
}
