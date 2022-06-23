using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossMechanics2 : MonoBehaviour
{
    //Posibles puntos de aparicion del Boss
    public GameObject spawnDL;
    public GameObject spawnDR;
    public GameObject spawnTL;
    public GameObject spawnTR;
    public GameObject spawnF;

    //Variables del estado del Boss
    public int spawnTime;
    public bool bossActive;
    public int randomAttack;

    //Variables del ataque con bolas de fuego
    public float fireballSpeed;
    public float fireballRate;
    public Transform[] fireballSpawn;
    public Rigidbody fireballPrefab;
    Rigidbody clone;

    //Variables del ataque Megabola
    public float megaBallSpeed;
    public Transform megaBallSpawn;
    public Rigidbody megaBallPrefab;

    //Variables ataque electrico
    public GameObject electricAttack;
    public GameObject electricBlink;
    public int electricTime;

    //Variables para orientar el Boss hacia el jugador
    public GameObject objectThatLooks;
    public GameObject objectToLook;
    public float yPos;
    private Vector3 objectToLookPosition;

    //Variables Teleport
    public ParticleSystem teleportEffect;
    public GameObject nose;
    public MeshRenderer myRender;

    //Variables de Salud e Invencibilidad del Boss
    public float life;
    public float maxlife;
    public bool godMode = false;
    public int godTime;
    public GameObject forcefield;
    public Image bossHealthBar;
    public ParticleSystem explosion;

    void Start()
    {
        life = maxlife;
        StartCoroutine("BossAttacks");
    }

    void Update()
    {
        lookAtPlayer();
        bossHealthBar.fillAmount = life / maxlife;
    }

    IEnumerator BossAttacks()
    {
        while (bossActive == true)
        {
            teleportEffect.Play();
            myRender.enabled = false;
            nose.SetActive(false);

            yield return new WaitForSeconds(spawnTime);

            myRender.enabled = true;
            nose.SetActive(true);
            teleportEffect.Play();

            randomAttack = Random.Range(0, 5);

            if (randomAttack == 0)
            {
                this.transform.position = spawnDL.transform.position;
                yield return new WaitForSeconds(3);
                StartCoroutine("FireballShooting");
                yield return new WaitForSeconds(3);
            }
            else if (randomAttack == 1)
            {
                this.transform.position = spawnDR.transform.position;
                yield return new WaitForSeconds(1);
                StartCoroutine("FireballShooting");
                yield return new WaitForSeconds(3);
            }
            else if (randomAttack == 2)
            {
                this.transform.position = spawnTL.transform.position;
                yield return new WaitForSeconds(1);
                ShootMegaEnergyBall();
                yield return new WaitForSeconds(3);
            }
            else if (randomAttack == 3)
            {
                this.transform.position = spawnTR.transform.position;
                yield return new WaitForSeconds(2);
                ShootMegaEnergyBall();
                yield return new WaitForSeconds(2);
            }
            else if (randomAttack == 4)
            {
                this.transform.position = spawnF.transform.position;
                electricBlink.SetActive(true);
                yield return new WaitForSeconds(electricTime);
                electricBlink.SetActive(false);
                electricAttack.SetActive(true);
                yield return new WaitForSeconds(electricTime / 2);
                electricAttack.SetActive(false);
            }
        }
    }

    IEnumerator FireballShooting()
    {
        for (int i = 0; i < 4; i++)
        {
            myRender.enabled = true;
            nose.SetActive(true);
            ShootFireball();
            yield return new WaitForSeconds(fireballRate);
        }
    }

    //Metodo que orienta la vision del Boss hacia el jugador
    private void lookAtPlayer()
    {
        objectToLookPosition = objectToLook.transform.position;
        objectToLookPosition.y = yPos;
        objectThatLooks.transform.LookAt(objectToLookPosition);
    }

    void ShootFireball()
    {
        clone = Instantiate(fireballPrefab, fireballSpawn[Random.Range(0, 2)].position, fireballSpawn[Random.Range(0, 2)].rotation) as Rigidbody;
        clone.AddForce(fireballSpawn[Random.Range(0, 2)].transform.right * fireballSpeed);
    }
    void ShootMegaEnergyBall()
    {
        clone = Instantiate(megaBallPrefab, megaBallSpawn.position, megaBallSpawn.rotation) as Rigidbody;
        clone.AddForce(megaBallSpawn.transform.right * megaBallSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (godMode == false)
        {
            if (other.gameObject.tag == "ArrowPlayer")
            {
                RecibirDanyo();
            }
        }
        if (other.gameObject.tag == "LancePrefab")
        {
            Destroy(other.gameObject);
        }

    }

    public void RecibirDanyo()
    {
        if (godMode == false)
        {
            if (life > 0)
            {
                --life;

                if (life >= 1)
                {
                    StartCoroutine("IniciarInvencibilidad");
                }
            }
            if (life <= 0)
            {
                StartCoroutine("BossDies");
            }
        }
    }

    //Se desactiva el Boss y se accede a la pantalla de victoria
    IEnumerator BossDies()
    {
        explosion.Play();
        bossHealthBar.enabled = false;
        myRender.enabled = false;
        nose.SetActive(false);
        bossActive = false;
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
        SceneManager.LoadScene("MenuVictoria");
    }

    //Breve periodo de invencibilidad al recibir impacto   
    IEnumerator IniciarInvencibilidad()
    {
        godMode = true;
        forcefield.SetActive(true);
        yield return new WaitForSeconds(godTime);
        forcefield.SetActive(false);
        godMode = false;
    }

}
