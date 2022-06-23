using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Puzzle : MonoBehaviour
{
    //Interruptor activado o desactivado
    public bool active = false; 

    //Referencias 
    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;
    public GameObject platform4;
    public GameObject platform5;
    public GameObject particle; 
    public TwoPointsMover twoPointsMover;


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && active==false)
        {
            if (this.gameObject.tag == "Switch_01")
            {
                twoPointsMover.enabled = true;
            }

            if (this.gameObject.tag == "Switch_02")
            {
                platform2.transform.Rotate(0, 0, 90);
            }

            if (this.gameObject.tag == "Switch_03")
            {
                particle.SetActive(true);
            }

            if (this.gameObject.tag == "Switch_04")
            {
                twoPointsMover.enabled = true;
            }

            if (this.gameObject.tag == "Switch_05")
            {
                platform5.SetActive(false);
            }

            if (this.gameObject.tag == "Switch_06")
            {
                platform1.SetActive(true);
            }

            active = true; 
        }

        else if (other.gameObject.tag == "Player" && active == true)
        {

            if (this.gameObject.tag == "Switch_01")
            {
                twoPointsMover.enabled = false;
            }

            if (this.gameObject.tag == "Switch_02")
            {
                platform2.transform.Rotate(0, 0, 90);
            }

            if (this.gameObject.tag == "Switch_03")
            {
                particle.SetActive(false);
            }

            if (this.gameObject.tag == "Switch_04")
            {
                twoPointsMover.enabled = false;
            }

            if (this.gameObject.tag == "Switch_05")
            {
                platform5.SetActive(true);
            }

            if (this.gameObject.tag == "Switch_06")
            {
                platform1.SetActive(false);
            }
  
            active = false;
        }
    }
}
