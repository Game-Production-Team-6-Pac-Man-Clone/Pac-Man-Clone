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
        this.movement = GetComponent<Movement>();
        this.homebase = GetComponent<GhostHomeBase>();
        this.retreat = GetComponent<GhostRetreat>();
        this.chase = GetComponent<GhostChase>();
        this.frightened = GetComponent<GhostFrightened>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();

                this.frightened.Disable();
        this.chase.Disable();
        this.retreat.Enable();
        
        if (this.homebase != this.initialBehavior){
            this.homebase.Disable();
    }

    if (this.initialBehavior != null){
        this.initialBehavior.Enable();
    }
}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (this.frightened.enabled){
                FindObjectOfType<GameManager>().GhostEaten(this);
            } else {
                FindObjectOfType<GameManager>().PlayerDefeated();
            }
        }
    }

}
