using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTeleport : MonoBehaviour
{

    Ghost ghost;

    public GameObject portal;



    // Start is called before the first frame update
    void Start()
    {
        ghost = gameObject.GetComponent<Ghost>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        StartCoroutine("Teleport");
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(6f);
        gameObject.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
    }
}
