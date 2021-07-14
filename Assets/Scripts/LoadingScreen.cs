using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine("Loading");
    }
    IEnumerator Loading()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main 2");
    }
}
