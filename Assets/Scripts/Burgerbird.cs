using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burgerbird : MonoBehaviour
{
    [SerializeField] private float minSpeed = 3f;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float gravityInput = 3f;
    private float gravityPlus;
    private float defaultGravity;
    Vector2 burgerPosition = Vector2.zero;
    Vector2 lastPosition = Vector2.zero;
    Vector2 currentVelocity;
    Vector2 oldVelocity;
    private float sqrSpeed; // "real" speed (square vector length per fixed update duration)
    private Rigidbody2D burgerbird;

    void Start()
    {
        burgerbird = GetComponent<Rigidbody2D>();
        defaultGravity = burgerbird.gravityScale;
        Vector2 burgerPosition = new Vector2(transform.position.x, transform.position.y);
        lastPosition = burgerPosition;
        oldVelocity = currentVelocity = burgerbird.velocity;
    }

    void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (verticalInput <= 0)
        {
            gravityPlus = Mathf.Abs(verticalInput) * gravityInput;
        }
        else
        {
            gravityPlus = 0;
        }
    }

    private void FixedUpdate()
    {
        // Add Gravity
        burgerbird.gravityScale = defaultGravity + gravityPlus;
        // Minimum Speed
        Vector2 speed = burgerbird.velocity;
        if (speed.x <= minSpeed)
        {
            speed.x = minSpeed;
            burgerbird.velocity = speed;
        }
        // square speed (faster than normal speed)
        sqrSpeed = burgerbird.velocity.sqrMagnitude;
        Debug.Log(sqrSpeed);
    }
}
