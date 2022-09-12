using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroTexts : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public int waitTime;

    private void Awake()
    {
        StartCoroutine("IntroTiming");
    }

    IEnumerator IntroTiming()
    {
        yield return new WaitForSeconds(2);
        text1.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        text2.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("DemoBoss");
    }
}
