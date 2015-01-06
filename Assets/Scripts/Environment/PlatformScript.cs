using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour
{
    EdgeCollider2D edgeCollider;
    GameController gc;

    void Awake()
    {
        gc = GameObject.Find("GameControllerObject").GetComponent<GameController>();
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
        } else if (other.gameObject.tag == "Enemy")
        {
            gc.killEnemy(other.gameObject);
            /*
            gc.currentEnemies--;
            Instantiate(gc.explosionObj, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            */
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
