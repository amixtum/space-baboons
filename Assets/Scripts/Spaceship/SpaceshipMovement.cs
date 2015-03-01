using UnityEngine;
using System.Collections;

public class SpaceshipMovement : MonoBehaviour {
    public float thrusterForce = 500f;
    public float torqueForce= 500f;

    private void Thrust(Vector3 direction)
    {
        this.rigidbody.AddForce(direction * thrusterForce);
    }
    private void Torque(Vector3 direction)
    {
        this.rigidbody.AddTorque(direction * torqueForce);
    }

    public void ForwardThrust()
    {
        Thrust(this.transform.forward);
    }
    public void UpThrust()
    {
        Thrust(this.transform.up);
    }
    public void DownThrust()
    {
        Thrust(-this.transform.up);
    }
    public void LeftThrust()
    {
        Thrust(-this.transform.right);
    }
    public void RightThrust() 
    {
        Thrust(this.transform.right);
    }
    public void BackThrust()
    {
        Thrust(-this.transform.forward);
    }

    public void PitchUp()
    {
        Torque(-this.transform.right);
    }
    public void PitchDown()
    {
        Torque(this.transform.right);
    }
    public void RollLeft()
    {
        Torque(this.transform.forward);
    }
    public void RollRight()
    {
        Torque(-this.transform.forward);
    }
   
}
