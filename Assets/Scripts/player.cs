using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class player : MonoBehaviour
{
    public float playerSpeed;

    private float horizontalScreenLimit = 2.9f;

    public Movement movement { get; private set; }

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.movement.SetDirection(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            this.movement.SetDirection(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.movement.SetDirection(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.movement.SetDirection(Vector2.right);
        }

        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x); //MAKES PAC-MAN LOOK FORWARD//
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);

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
            transform.position = new Vector2((transform.position.x * -1f) + .5f, transform.position.y);
        }
        if (transform.position.x < -horizontalScreenLimit)
                {
            transform.position = new Vector2((transform.position.x * -1f) - .5f, transform.position.y);
        }
    }
    }
