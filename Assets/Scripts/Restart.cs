using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(endscreen());
    }
    IEnumerator endscreen()
    {
        yield return new WaitForSecondsRealtime(5);
        SceneManager.LoadScene("MainMenu");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
