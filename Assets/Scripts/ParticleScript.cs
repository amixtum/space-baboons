using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {
    public ParticleSystem left;
    public ParticleSystem right;
    public GameObject laser;
    public Transform frontOfShip;

    public void ChangeParticleSpeed(float newSpeed)
    {
        left.startSpeed = newSpeed;
        right.startSpeed = newSpeed; 
    }

    public float GetParticleSpeed()
    {
        return left.startSpeed;
    }

    public void ShootLaser()
    {
        

        Quaternion laserRotation = Quaternion.FromToRotation(Vector3.up, frontOfShip.up) * 
                                   Quaternion.FromToRotation(frontOfShip.up, frontOfShip.forward) *
                                   Quaternion.FromToRotation(frontOfShip.right, frontOfShip.forward);
        //Quaternion

        Instantiate(laser, frontOfShip.position, laserRotation);
    }
}
