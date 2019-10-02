using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burgerbird : MonoBehaviour
{
    #region Declaration
    [SerializeField] private float gravityInput = 3f;
    [SerializeField] private float minVelocityX = 3f;
    [SerializeField] private float maxVelocityY = 3f;

    [Tooltip("Square Magnitude of Velocity (Square Speed)")]
    [SerializeField] float camZoom = 300f;
    private float gravityPlus;
    private float defaultGravity;
    private Vector2 velocity;
    private Rigidbody2D burgerbird;
    #endregion
    void Start()
    {
        burgerbird = GetComponent<Rigidbody2D>();
        defaultGravity = burgerbird.gravityScale;
    }

    void Update()
    {
        #region Add Gravity
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (verticalInput <= 0)
            gravityPlus = Mathf.Abs(verticalInput) * gravityInput;
        else
            gravityPlus = 0;
        burgerbird.gravityScale = defaultGravity + gravityPlus;
        #endregion

        #region Minimum Velocity
        velocity = burgerbird.velocity;
        if (velocity.x <= minVelocityX)
            burgerbird.velocity = new Vector2(minVelocityX, velocity.y);
        #endregion

        #region Cam Zoom
        // Switch...
        if (velocity.sqrMagnitude > camZoom)
            Debug.Log("Velocity Square Magnitude higher than: " + camZoom);
        else
            Debug.Log("Zoom in!");
        #endregion
    }
}
