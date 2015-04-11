using UnityEngine;
using System.Collections;

public class LaserShot : MonoBehaviour
{
    public float speed;
    public float timeUntilDeath;

    GameController gc;

    void Start()
    {
        gc = GameObject.Find("GameControllerObject").GetComponent<GameController>();

        GetComponent<Rigidbody2D>().angularVelocity = -720f;
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        Destroy(gameObject, timeUntilDeath);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            if (other.gameObject.tag == "Enemy")
            {
                gc.killEnemy(other.gameObject);
                /*
                gc.currentEnemies--;
                Instantiate(gc.explosionObj, other.gameObject.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                */
            } else
            {
                Instantiate(gc.explosionObj, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
