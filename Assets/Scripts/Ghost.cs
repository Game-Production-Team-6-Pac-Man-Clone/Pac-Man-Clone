using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    Rigidbody2D rb;

    public Transform target;
    public Player player;

    public GameObject portal;

    public Ghost ghost;

    public int points = 200;
    public GhostFrightened frightened { get; private set; }


    // movement speed
    [SerializeField] float speed;
    [SerializeField] private float maxSpeed;

    // possible movent directions
    Vector2[] directions = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };

    int directionIndex = 1;

    // doesn't have to be serialized
    [SerializeField] Vector2 currentDir;

    // how far to look ahead
    [SerializeField] float rayDistance;

    // which layers to raycast for
    [SerializeField] LayerMask rayLayer;


 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentDir = directions[directionIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, currentDir, rayDistance, rayLayer);
        Vector3 endpoint = currentDir * rayDistance;
        
        Debug.DrawLine(transform.position, transform.position + endpoint, Color.green);

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = (Vector2)Vector3.ClampMagnitude((Vector3)rb.velocity, maxSpeed);
        }

        
        if(hit2D.collider != null)
        {
            // check if wall ahead
            if (hit2D.collider.gameObject.CompareTag("wall"))
            {
                ChangeDirection();
            }

            // check if player ahead
            if (hit2D.collider.gameObject.CompareTag("Player"))
            {
                // deal damage;
                print("player ahead!");
            }
        }
    }


    void ChangeDirection()
    {
        // randomly select between -1 and 1;
        directionIndex += Random.Range(0, 2) * 2 - 1;

        // keeps index from exceeding 3
        int clampedIndex = directionIndex % directions.Length;

        // keep index positive
        if(clampedIndex < 0)
        {
            clampedIndex = directions.Length + clampedIndex;
        }

        // temporary freeze movement before set the new direction
        rb.velocity = Vector2.zero;

        // set the current direction from the directions array
        currentDir = directions[clampedIndex];
    }

    void FixedUpdate()
    {
        // move in current direction
        rb.AddForce(currentDir * speed);
    }


        private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (player.isInhaling == true){
                gameObject.SetActive(false);
                Invoke(nameof(ResetState), 6.0f);
                gameObject.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
                
            } else {
                FindObjectOfType<GameManager>().PlayerDefeated();
            }
        }
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);

        }
}