using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Animation Variables
    Animater anim;
    public bool moving = false;

    //Movement Variables
    Rigidbody2D rb; //create reference fro rigidbody bc jump physics
    public float jumpForce; //the force that will be added to the vertical component of player's velocity
    public float speed;


    //Ground Check Variables
    public LayerMask groundLayer;
    public Transform groundCheck;
    public bool isGrounded;

    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, .5f, groundLayer);

        Vector3 newPosition = transform.position;
        Vector3 newScale = transform.localScale;
        float currentScale = Mathf.Abs(transform.localScale.x);

        if(Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) 
        {
            newPosition.x -= speed;
            newScale.x = -currentScale;
            moving = true;
        }

        if(Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition.x += speed;
            newScale.x = currentScale;
            moving = true;
        }

        if((Input.GetKeyDown("w") || Input.GetKey(KeyCode.UpArrow)) && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
        
        transform.position = newPosition;
        transform.localScale = newScale;
    }

}
