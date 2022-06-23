using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_arrows : MonoBehaviour
{
    public GameObject arrow;
    public float cont;
    public float lim = 2;
    public int min = 1;
    public int max = 7;
    public float vel = 0;

    // Start is called before the first frame update
    void Start()
    {
        calculate();
    }

    // Update is called once per frame
    void Update()
    {
        cont = cont + Time.deltaTime;

        if (cont > lim)
        {
            arrow.GetComponent<VerticalArrowMovement>().vel = vel;
            GameObject newArrow = (GameObject)Instantiate(arrow, this.transform.position, this.transform.rotation);

            cont = 0;
            calculate();
        }
    }
    void calculate()
    {
        lim = Random.Range(min, max);
    }
}
