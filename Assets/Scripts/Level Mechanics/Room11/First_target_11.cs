using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_target_11 : MonoBehaviour
{
    public GameObject Lava;
    public GameObject Target_Container;
    public GameObject Box;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ArrowPlayer")
        {
            Destroy(Lava);
            Destroy(Target_Container);
            Destroy(Box);
        }
    }
}
