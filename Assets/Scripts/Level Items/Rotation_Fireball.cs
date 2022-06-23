using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Fireball : MonoBehaviour
{

    public float Rot = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate( Rot * Time.deltaTime, 0, 0 );    
    }
}
