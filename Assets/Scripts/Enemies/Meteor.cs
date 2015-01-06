using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Vector3 direction = transform.right;
        direction.y = Random.Range(-1f, 0f);
        rigidbody2D.velocity = direction.normalized * speed;
    }

}
