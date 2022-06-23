using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingBox_3 : MonoBehaviour
{
    public Material myMaterial;
    public PlayerHealth playerHealth;
    public GameObject particle;
    public GameObject collectible;

    public float seconds;

    public bool isActive;
    public bool isGreen = false;
    public bool isRed = false;
    public bool isBlue = false;

    void Start() { StartCoroutine("ChangeFace"); }

    IEnumerator ChangeFace()
    {
        while (isActive)
        {
            turnToGreen();
            yield return new WaitForSeconds(seconds);
            turnToRed();
            yield return new WaitForSeconds(seconds);
            turnToBlue();
            yield return new WaitForSeconds(seconds);
        }
    }

    void turnToRed()
    {
        isGreen = false;
        isRed = true;
        isBlue = false;
        myMaterial.color = Color.red;
    }

    void turnToGreen()
    {
        isGreen = true;
        isRed = false;
        isBlue = false;
        myMaterial.color = Color.green;
    }

    void turnToBlue()
    {
        isGreen = false;
        isRed = false;
        isBlue = true;
        myMaterial.color = Color.blue;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isGreen)
            {
                collectible.SetActive(true);
                Destroy(this.gameObject);
            }
            else if (isRed)
            {
                playerHealth.RecibirDanyo();
            }
            else if (isBlue)
            {
                particle.SetActive(true);
            }
        }
    }

}
