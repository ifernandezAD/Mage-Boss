using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Spike : MonoBehaviour
{
    public GameObject Spike;
    public float cont;
    public float lim = 2;
    public int min = 1;
    public int max = 10;

    // Start is called before the first frame update
    void Start()
    {
        calculo();
    }

    // Update is called once per frame
    void Update()
    {
        cont = cont + Time.deltaTime;

        if (cont > lim)
        {
            GameObject newSpike = (GameObject)Instantiate(Spike, this.transform.position, this.transform.rotation);


            cont = 0;
            calculo();
        }
    }
    void calculo()
    {
        lim = Random.Range(min, max);
    }
}
