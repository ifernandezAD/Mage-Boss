using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighTarget : MonoBehaviour
{
    public Transform puntoDestino;
    public Transform puntoOrigen;
    public TwoPointsMover movimientoScript;
    public Transform plataforma;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ArrowPlayer")
        {
            movimientoScript.enabled = false;
            plataforma.position = puntoOrigen.position;

            StartCoroutine("CambioMovimimento");

        }
    }

    IEnumerator CambioMovimimento()
    {
        movimientoScript.origen = puntoOrigen;
        movimientoScript.destino = puntoDestino;
        movimientoScript.speed = 0.1f;
        yield return new WaitForSeconds(1f);
        movimientoScript.enabled = true;
    }

}
