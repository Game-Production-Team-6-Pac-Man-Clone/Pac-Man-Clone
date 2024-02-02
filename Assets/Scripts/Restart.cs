using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    
    private void Start()
    {
        StartCoroutine(endscreen());
    }
    IEnumerator endscreen()
    {
        yield return new WaitForSecondsRealtime(5);
        SceneManager.LoadScene("MainMenu");
    }
    
}
