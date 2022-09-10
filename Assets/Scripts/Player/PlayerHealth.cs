using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public Transform checkPoint;
    [SerializeField] int startingLives=3;
    [SerializeField] int currentLives;
    [SerializeField] int startingHealth = 3;
    [SerializeField] int currentHealth ;
    [SerializeField] Text lifesIndicator;

    private bool godMode;
    public float godModeDuration;
    public SkinnedMeshRenderer renderer;

    [Range(0, 100)]
    public int rate;
    [Range(0, 1)]
    public float delay;

    public float dieDelay = 1;

    private UIManager uiManager;

    private PlayerSoundManager psm;
    private PlayerMovement pm;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "DemoBoss")
        {
            currentHealth = PlayerPrefs.GetInt("currentHealth", startingHealth);
            currentLives = PlayerPrefs.GetInt("currentLives", currentLives);
        }        
        else
        {
            currentHealth = startingHealth;
            currentLives = startingLives;
        } 


        lifesIndicator.text = "x " + currentLives;
        //renderer = GetComponentInChildren<MeshRenderer>();
        uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
        uiManager.CrearVidasUI(currentHealth);
        psm = GetComponent<PlayerSoundManager>();
        pm = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Lava")
        {
            Debug.Log("Vidas: " + currentLives);
            Morir();

        }

        if (other.tag == "Saw"|| other.tag == "Fireball" || other.tag == "Electric" )
        {
              RecibirDanyo();            

        }

        if (other.tag == "CheckPoint")
        {
           
            checkPoint = other.transform;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Spike" || collision.gameObject.tag == "Enemy_Arrow"|| collision.gameObject.tag == "Boss")
        {
            RecibirDanyo();
        }
    }

    public void RecibirDanyo()
    {
        if (godMode == false)
        {            
            if (currentHealth > 0)
            {
               
                currentHealth -= 1;
                uiManager.CrearVidasUI(currentHealth);
                if (currentHealth >= 1)
                {
                    psm.PlayAudioDamage();
                    StartCoroutine("IniciarInvencibilidad");
                }
            }
            if (currentHealth <= 0)
            {
                Morir();
            }
        }

    }

    public void Morir()
    {
        psm.PlayAudioDie();
        if (godMode == false)
        {
            if (currentLives > 1)
            {
                currentLives--;

                lifesIndicator.text = "x " + currentLives;

                StartCoroutine("RespawnPlayer");

                //Resetear la lava ascendente si muere el player
                GameObject risingLava = GameObject.Find("RisingLava");
                if (risingLava != null)
                {
                    risingLava.GetComponent<LavaRising>().ResetLava();
                }

            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }

    }

    public void saveLivesStatus()
    {
        PlayerPrefs.SetInt("currentHealth", currentHealth);
        PlayerPrefs.SetInt("currentLives", currentLives);
    }

    IEnumerator RespawnPlayer()
    {
        godMode = true;
        pm.enabled = false;
        GetComponent<PlayerHealth>().enabled = false;
        yield return new WaitForSeconds(dieDelay);
        this.transform.position = checkPoint.position;
        currentHealth = startingHealth;
        uiManager.CrearVidasUI(startingHealth);
        pm.enabled = true;
        GetComponent<PlayerHealth>().enabled = true;
        godMode = false;
    }


    //Breve periodo de invencibilidad al recibir daño
    IEnumerator IniciarInvencibilidad()
    {
        godMode = true;
        for (int i=0; i < rate; i++)
        {
            renderer.enabled = !renderer.enabled;
            yield return new WaitForSeconds(delay);
        }
        renderer.enabled = true;
        godMode = false;

    }
}
