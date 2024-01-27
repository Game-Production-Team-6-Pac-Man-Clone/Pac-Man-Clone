using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellete : MonoBehaviour
{
    public int points = 10;

    protected virtual void Eat()
    {
        FindObjectOfType<GameManager>().PelletEaten(this);
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