using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {
    public ParticleSystem left;
    public ParticleSystem right;

    public void ChangeParticleSpeed(float newSpeed)
    {
        left.startSpeed = newSpeed;
        right.startSpeed = newSpeed; 
    }

    public float GetParticleSpeed()
    {
        return left.startSpeed;
    }
}
