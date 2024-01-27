using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Movement movement { get; private set; }
    
    public GhostHomeBase homebase { get; private set; }

    public GhostRetreat retreat { get; private set; }

    public GhostChase chase { get; private set; }

    public GhostFrightened frightened { get; private set; }
    public GhostBehavior initialBehavior;
    public Transform player;


    public int points = 200;


    private void Awake()
    {
        movement = GetComponent<Movement>();
        homebase = GetComponent<GhostHomeBase>();
        retreat = GetComponent<GhostRetreat>();
        chase = GetComponent<GhostChase>();
        frightened = GetComponent<GhostFrightened>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        movement.ResetState();

                this.frightened.Disable();
        chase.Disable();
        retreat.Enable();
        
        if (homebase != this.initialBehavior){
            homebase.Disable();
    }

    if (initialBehavior != null){
        initialBehavior.Enable();
    }
}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (frightened.enabled){
                FindObjectOfType<GameManager>().GhostEaten(this);
            } else {
                FindObjectOfType<GameManager>().PlayerDefeated();
            }
        }
    }

}
