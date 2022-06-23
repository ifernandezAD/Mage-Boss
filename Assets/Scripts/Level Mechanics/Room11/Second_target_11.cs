using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_target_11 : MonoBehaviour
{
    public GameObject Target_Door;
    public GameObject Target_Door_Prefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ArrowPlayer")
        {
            Destroy(Target_Door);

        }
        
    }

// Update is called once per frame
void Update()
    {
        
    }
}
