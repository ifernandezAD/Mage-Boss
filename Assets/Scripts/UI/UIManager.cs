using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int vidasInicial;
    public GameObject panelVidas;
    public Image prefabImagenVida;
    public Transform lifeItemSpawn;

    private float lifeItemAnchor;

    // Start is called before the first frame update
    void Start()
    {
        lifeItemAnchor = prefabImagenVida.rectTransform.rect.width;
        Debug.Log("Ancho vida: " + lifeItemAnchor);
        CrearVidasUI(vidasInicial);
    }

    public void CrearVidasUI(int numeroVidas)
    {
        LimpiarPanel();
        for (int i = 0; i < numeroVidas; i++)
        {
            Vector3 nuevaPosicion = new Vector3(lifeItemSpawn.position.x + i * (lifeItemAnchor+5), lifeItemSpawn.position.y, lifeItemSpawn.position.z);
            GameObject nuevaImagenVida = Instantiate(prefabImagenVida.gameObject, nuevaPosicion, transform.rotation);
            nuevaImagenVida.transform.SetParent(panelVidas.transform);
            nuevaImagenVida.transform.localScale = Vector3.one;
        }
    }


    private void LimpiarPanel()
    {
        foreach (Transform child in panelVidas.transform)
        {
            Destroy(child.gameObject);
        }
    }


}
