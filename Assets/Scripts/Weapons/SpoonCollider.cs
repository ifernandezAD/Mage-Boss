using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonCollider : MonoBehaviour
{
    public GameObject spoon;
    
    void Update()
    {
        this.transform.position = spoon.transform.position; 
    }
}
