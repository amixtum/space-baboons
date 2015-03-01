using UnityEngine;
using System.Collections;

public class PlayerSpaceShipController : MonoBehaviour {
    private SpaceshipMovement movementScript;

	void Start () {
        movementScript = this.GetComponent<SpaceshipMovement>();
	}

    void FixedUpdate()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        RotationHandling();
        AccelerationHandling();
    }

    private void RotationHandling()
    {
        if (Input.GetKey(KeyCode.W))
        {
            movementScript.PitchDown();
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementScript.RollLeft();
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementScript.PitchUp();
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementScript.RollRight();
        }
    }

    private void AccelerationHandling()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            movementScript.ForwardThrust();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movementScript.UpThrust();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movementScript.LeftThrust();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movementScript.RightThrust();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movementScript.DownThrust();
        }
    }
}
