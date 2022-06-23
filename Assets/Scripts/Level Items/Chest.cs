using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Rigidbody mirigid;
    public GameObject Weapon;


    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        //Hammer

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerSoundManager>().PlayAudioChest();

            Destroy(this.gameObject);
            GameObject newWeapon = (GameObject)Instantiate(Weapon, this.transform.position, this.transform.rotation);

        }

    }
}
