using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 0;

    [SerializeField]
    private Rigidbody2D playerRigidbody2d = null;

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

        playerRigidbody2d.velocity = velocity;
    }
}
