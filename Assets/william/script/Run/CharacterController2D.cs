using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float jump_height = 1;

    private Rigidbody2D rigidbody2D;

    private int jump_count_limit = 2;
    private int jump_count_current = 2;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jump_count_current <2)
        {
            jump_count_current++;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jump_height);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D Ground");
        if (collision.gameObject.name == "Ground")
        {
            jump_count_current = 0;
        }
    }
}
