using System.Collections;
using UnityEngine;

public class PlayerItemsManager : MonoBehaviour
{

    public float arrowSpeed = 18.0f;
    public float lanceSpeed = 40f;
    public Transform arrowSpawn;
    public Transform lanceSpawn;
    public Rigidbody arrowPrefab;
    public Rigidbody lancePrefab;
    public GameObject spoon;
    public GameObject spoonTrigger;


    Rigidbody clone;

    public float appleCadency = 0.8f;
    private bool canShootApple = true;
    public float appleDelay;
    public float lanceCadency = 1f;
    private bool canShootLance = true;
    public float spearDelay;
    public float spoonDelay;
    private bool canAttackSpoon = true;
    public float jumpingTime;
   

    public CameraShake cameraShake;

    private PlayerSoundManager psm;
    private Animator animator;

    private void Start()
    {
        psm = GetComponent<PlayerSoundManager>();
        animator = GetComponentInChildren<Animator>();
    }

    
    private void OnEnable()
    {
        PlayerMovement.jumping += DisableOnJumping;
        //PlayerMovement.onGround += EnableWeapons;
    }

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

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (canAttackSpoon )
            {
                StartCoroutine("SpoonAttack");
            }
        }

    }

    IEnumerator ThrowSpear()
    {
        animator.SetTrigger("Spear");
        DisableWeapons();
        yield return new WaitForSeconds(spearDelay);
        clone = Instantiate(lancePrefab, lanceSpawn.position, lanceSpawn.rotation) as Rigidbody;
        clone.AddForce(arrowSpawn.transform.right * arrowSpeed);
        psm.PlayAudioFire();
        yield return new WaitForSeconds(lanceCadency);
        EnableWeapons();
    }

    IEnumerator ThrowApple()
    {
        animator.SetTrigger("Apple");
        DisableWeapons();
        yield return new WaitForSeconds(appleDelay);
        clone = Instantiate(arrowPrefab, arrowSpawn.position, arrowSpawn.rotation) as Rigidbody;
        clone.AddForce(arrowSpawn.transform.up * arrowSpeed);
        psm.PlayAudioFire();
        yield return new WaitForSeconds(appleCadency);
        EnableWeapons();
    }

    IEnumerator SpoonAttack()
    {
        animator.SetTrigger("Hammer");
        DisableWeapons();
        spoon.SetActive(true);
        spoonTrigger.SetActive(true);
        yield return new WaitForSeconds(spoonDelay);
        StartCoroutine(cameraShake.CameraShaking());
        spoon.SetActive(false);
        spoonTrigger.SetActive(false);
        EnableWeapons();
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

    void EnableWeapons()
    {
        canShootLance = true;
        canAttackSpoon = true;
        canShootApple = true;
    }

    void DisableWeapons()
    {
        canShootLance = false;
        canAttackSpoon = false;
        canShootApple = false;
    }

    void DisableOnJumping()
    {
        StartCoroutine("DisableOnJumpingCorrutine");
    }

    IEnumerator DisableOnJumpingCorrutine()
    {
        DisableWeapons();
        yield return new WaitForSeconds(jumpingTime);
        EnableWeapons();        
    }
}
