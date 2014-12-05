using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;

    bool isTouchingGround;
    bool isWalking;
    float scale;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        scale = transform.localScale.x;
    }
	
    // Update is called once per frame
    void Update()
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
        vertical = vertical <= 0 ? rigidbody2D.velocity.y : vertical * speed;
        Vector2 velocity = new Vector2(horizontal * speed, vertical);

        rigidbody2D.velocity = velocity;

        Vector3 localScale = transform.localScale;
        if (horizontal < 0)
        {
            localScale.x = -scale;
        } else if (horizontal > 0)
        {
            localScale.x = scale;
        }

        anim.SetBool("IsWalking", (isTouchingGround && horizontal != 0));
        anim.SetBool("IsFlying", !isTouchingGround || Mathf.Abs(rigidbody2D.velocity.y) >= 1);

        transform.localScale = localScale;
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
