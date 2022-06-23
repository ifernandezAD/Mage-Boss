using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaHundible : MonoBehaviour
{
    bool seHaIniciadoBajada = false;
    public bool estaBajando = false;
    public float speed;
    private Vector3 posicionInicial;
    public float tiempoEspera;

    private Color initialColor;

    private void Awake()
    {
        posicionInicial = transform.position;
        initialColor = GetComponent<Renderer>().material.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!seHaIniciadoBajada && collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.SetColor("_Color",Color.red);
            seHaIniciadoBajada = true;
            collision.gameObject.transform.SetParent(this.transform);
            Invoke("CambiarEstado", tiempoEspera);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

    private void Update()
    {        
        if (estaBajando)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }

    private void CambiarEstado()
    {
        estaBajando = true;
       // GetComponent<Flasher>().Flash();
    }

    public void RestaurarEstadoInicial()
    {
        GetComponent<Renderer>().material.SetColor("_Color", initialColor);
        transform.position = posicionInicial;
        seHaIniciadoBajada = false;
        estaBajando = false;
    }

    private void OnBecameInvisible()
    {
        RestaurarEstadoInicial();
    }

}
