using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    public Animator myAnim;

    void Start()
    {
        myAnim.SetBool("Victory",true);
    }
}
