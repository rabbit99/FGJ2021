using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float jump_height = 1;

    public Rigidbody2D rigidbody2D;

    public int jump_count_limit = 2;
    public int jump_count_current = 2;
    private bool isGround = false;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jump_count_current < jump_count_limit)
        {
            Jump();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D Ground ");
        if (collision.gameObject.name == "Ground")
        {
            jump_count_current = 0;
            isGround = true;
            animator.SetBool("jump", false);
        }
    }

    public void Jump()
    {
        Debug.Log("jump");
        jump_count_current++;
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jump_height);
        animator.SetBool("jump", true);
    }
}
