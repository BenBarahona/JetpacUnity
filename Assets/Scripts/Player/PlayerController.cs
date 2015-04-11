using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;

    bool isTouchingGround;
    bool isWalking;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
	
    // Update is called once per frame
    void Update()
    {

    }

    public void Die()
    {
        
    }

    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Move(v, h);
    }

    void Move(float vertical, float horizontal)
    {
        vertical = vertical <= 0 ? GetComponent<Rigidbody2D>().velocity.y : vertical * speed;
        Vector2 velocity = new Vector2(horizontal * speed, vertical);

        GetComponent<Rigidbody2D>().velocity = velocity;

        if (horizontal < 0 && transform.right.x == 1)
        {
            transform.RotateAround(transform.position, Vector3.up, -180);
        } else if (horizontal > 0 && transform.right.x == -1)
        {
            transform.RotateAround(transform.position, Vector3.up, 180);
        }

        anim.SetBool("IsWalking", (isTouchingGround && horizontal != 0));
        anim.SetBool("IsFlying", !isTouchingGround || Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) >= 1);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platforms" || other.gameObject.tag == "BottomPlatform")
        {
            isTouchingGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platforms" || other.gameObject.tag == "BottomPlatform")
        {
            isTouchingGround = false;
        }
    }


}
