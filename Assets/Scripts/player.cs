using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Player : MonoBehaviour
{
    public float playerSpeed;

    private float horizontalScreenLimit = 2.9f;

    public bool isInhaling;

    public bool playerDeath;

    private Animator animator;

    public Movement movement { get; private set; }

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        isInhaling = false;
        playerDeath = false;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (playerDeath == true)
        {
            animator.Play("KirbyDie");
            
        }
        else { }

        if (Input.GetKeyDown(KeyCode.W))
        {
            this.movement.SetDirection(Vector2.up);

            if (isInhaling == true)
            {
                animator.Play("KirbySuckUp");
            }
            else if (isInhaling == false)
            {
                animator.Play("KirbyUp");
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            this.movement.SetDirection(Vector2.down);

            if (isInhaling == true)
            {
                animator.Play("KirbySuckDown");
            }
            else if (isInhaling == false)
            {
                animator.Play("KirbyDown");
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.movement.SetDirection(Vector2.left);

            if (isInhaling == true)
            {
                animator.Play("KirbySuckLeft");
            }
            else if (isInhaling == false)
            {
                animator.Play("KirbyLeft");
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.movement.SetDirection(Vector2.right);

            if (isInhaling == true)
            {
                animator.Play("KirbySuckRight");
            }
            else if (isInhaling == false)
            {
                animator.Play("KirbyRight");
            }

        
        }
        
        //float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x); //MAKES PAC-MAN LOOK FORWARD//
        //this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);

        limit();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();
        }

    void limit()
    {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal"), 0) * Time.deltaTime * playerSpeed);
        if (transform.position.x > horizontalScreenLimit)
        {
            transform.position = new Vector2((transform.position.x * -1f) + .3f, transform.position.y);
        }
        if (transform.position.x < -horizontalScreenLimit)
                {
            transform.position = new Vector2((transform.position.x * -1f) - .3f, transform.position.y);
        }
    }}


