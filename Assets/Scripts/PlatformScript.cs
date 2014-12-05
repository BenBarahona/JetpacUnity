using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour
{
    EdgeCollider2D edgeCollider;

    void Awake()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            edgeCollider.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            edgeCollider.enabled = true;
        }
    }
}
