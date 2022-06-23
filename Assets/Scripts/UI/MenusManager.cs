using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusManager : MonoBehaviour
{

    public void LoadLevel()
    {
        SceneManager.LoadScene("NivelPrincipal");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuInicio");
    }

}
