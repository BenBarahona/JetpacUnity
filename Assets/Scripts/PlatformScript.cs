using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour
{
    bool playerIntercepting;
    GameObject playerObject;
    EdgeCollider2D edgeCollider;

    void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    void Update()
    {
        //edgeCollider.enabled = playerObject.transform.position.y > transform.position.y && !playerIntercepting;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            edgeCollider.enabled = false;
            playerIntercepting = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            edgeCollider.enabled = true;
            playerIntercepting = false;
        }
    }
}
