using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {
    public ParticleSystem left;
    public ParticleSystem right;
    public GameObject laser;
    public Transform frontOfShip;

    public float laser_length = 200f;

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
        Vector3 direction = frontOfShip.parent.forward;
        float length = laser_length;
        Vector3 start = frontOfShip.parent.position + frontOfShip.localPosition;
        Vector3 end = start + (length * direction);

        GameObject lzr = Instantiate(laser, start, Quaternion.identity) as GameObject;
        lzr.transform.position = end;
    }
}
