using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager = null;

    [SerializeField]
    private float playerSpeed = 0;

    [SerializeField]
    private Rigidbody2D playerRigidbody2d = null;

    [SerializeField]
    private Animator animator = null;

    [SerializeField]
    private SpriteRenderer spriteRenderer = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            return;
        }

        Vector3 velocity = Vector3.zero;
        velocity.x += context.ReadValue<Vector2>().x * playerSpeed;
        if (velocity.x != 0)
        {
            animator.SetBool("isMoving", true);
            if (velocity.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        playerRigidbody2d.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            gameManager.GetPoint();
        }
    }
}
