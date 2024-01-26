using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellete : MonoBehaviour
{
    public int point = 10;

    protected virtual void Eat()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            Eat();
        }
    }

    void Start()
    {

    }


    void Update()
    {

    }
}