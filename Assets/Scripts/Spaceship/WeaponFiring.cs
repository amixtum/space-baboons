using UnityEngine;
using System.Collections;

public class WeaponFiring : MonoBehaviour {
    public GameObject singularityBall;
    public Transform cannonTransform;

    void FixedUpdate()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(singularityBall, cannonTransform.position, Quaternion.identity) as GameObject;

            projectile.GetComponent<SingularityProjectileScript>().Fire(cannonTransform.forward);
        }
    }
}
