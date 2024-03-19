using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Tooltip("The game manager")]
    [SerializeField]
    private GameManager gameManager = null;

    [Tooltip("The speed the player will move")]
    [SerializeField]
    private float playerSpeed = 0;

    [Tooltip("The player's rigidbody")]
    [SerializeField]
    private Rigidbody2D playerRigidbody2d = null;

    [Tooltip("The player's animator")]
    [SerializeField]
    private Animator animator = null;

    [Tooltip("The player's sprite renderer")]
    [SerializeField]
    private SpriteRenderer spriteRenderer = null;

    [Tooltip("The player's audio source")]
    [SerializeField]
    private AudioSource audioSource = null;

    /// <summary>
    /// This function is called when the player uses (or stops using) the move buttons
    /// </summary>
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
            audioSource.Play();
            gameManager.GetPoint();
        }
    }
}
