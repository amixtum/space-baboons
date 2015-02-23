using UnityEngine;
using System.Collections;

public class SpaceshipMovement : MonoBehaviour {
    public float thrusterForce = 500f;
    public float torqueForce= 500f;

    public float particleInterpolate = 0.5f;
    public float maxThrusterLength = -2f;
    public float minThrusterLength = -0.5f;

    private bool playingEngineNoise = false;

    void FixedUpdate()
    {
        HandleInput();
        PlayEngineNoise();
    }

    private void HandleInput()
    {
        RotationHandling();
        AccelerationHandling();
        EffectsLogic();
    }

    private void PlayEngineNoise()
    {
        if (playingEngineNoise)
        {
            if (!this.GetComponent<AudioSource>().isPlaying)
            {
                this.GetComponent<AudioSource>().Play();
            }
        }
        if (!playingEngineNoise)
        {
            this.GetComponent<AudioSource>().Stop();
        }
    }

    private void RotationHandling()
    {
        if (Input.GetKey(KeyCode.W))
        {
            PitchDown();
        }
        if (Input.GetKey(KeyCode.A))
        {
            RollLeft();
        }
        if (Input.GetKey(KeyCode.S))
        {
            PitchUp();
        }
        if (Input.GetKey(KeyCode.D))
        {
            RollRight();
        }
    }

    private void AccelerationHandling()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ForwardThrust();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            UpThrust();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            LeftThrust();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            RightThrust();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            DownThrust();
        }
    }

    private void EffectsLogic()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playingEngineNoise = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playingEngineNoise = false;
        }
    }

    private void Thrust(Vector3 direction)
    {
        this.rigidbody.AddForce(direction * thrusterForce);
    }
    private void Torque(Vector3 direction)
    {
        this.rigidbody.AddTorque(direction * torqueForce);
    }

    private void ForwardThrust()
    {
        Thrust(this.transform.forward);
    }
    private void UpThrust()
    {
        Thrust(this.transform.up);
    }
    private void DownThrust()
    {
        Thrust(-this.transform.up);
    }
    private void LeftThrust()
    {
        Thrust(-this.transform.right);
    }
    private void RightThrust() 
    {
        Thrust(this.transform.right);
    }

    private void PitchUp()
    {
        Torque(-this.transform.right);
    }
    private void PitchDown()
    {
        Torque(this.transform.right);
    }
    private void RollLeft()
    {
        Torque(this.transform.forward);
    }
    private void RollRight()
    {
        Torque(-this.transform.forward);
    }
   
}
