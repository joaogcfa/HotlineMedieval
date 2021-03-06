using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 velocidade;
    public float speed = 10.0f;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");


        Vector3 desiredVelocity = inputX * transform.right + inputY * transform.forward;

        velocidade = new Vector2(inputX * speed, inputY * speed);
        rb.MovePosition(rb.position + velocidade * Time.fixedDeltaTime);

        if (inputX > 0)
        {
            transform.localScale = new Vector3(5f, 5f, 1f);
            playerAnimator.SetTrigger("Running");
        }
        else if (inputX < 0)
        {
            transform.localScale = new Vector3(-5f, 5f, 1f);
            playerAnimator.SetTrigger("Running");
        }
        else if (inputY < 0 || inputY > 0)
        {
            playerAnimator.SetTrigger("Running");
        }
        else
        {
            playerAnimator.SetBool("Running", false);
        }
    }
}
