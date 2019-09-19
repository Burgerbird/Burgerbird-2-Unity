using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJetpack : MonoBehaviour
{

	public float jetpackForce = 75.0f;
	public float gravitation = 13.0f;
	public float forwardMovementSpeed = 3.0f;
	private Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate() 
	{
		bool jetpackActive = Input.GetButton("Fire1");
		if (jetpackActive)
		{
			playerRigidbody.AddForce(new Vector2(0, jetpackForce));
		}

		Vector2 newVelocity = playerRigidbody.velocity;
		newVelocity.x += forwardMovementSpeed;
		playerRigidbody.velocity = newVelocity;

		// Winkel der Rotation einschränken
		Vector3 euler = transform.eulerAngles;
		if (euler.z > 180) euler.z = euler.z - 360;
		euler.z = Mathf.Clamp(euler.z, -80, 70);
		transform.eulerAngles = euler;
	}

}
