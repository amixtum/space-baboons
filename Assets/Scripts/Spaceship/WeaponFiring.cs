using UnityEngine;
using System.Collections;

public class WeaponFiring : MonoBehaviour {
    public GameObject singularityBall;
    public Transform cannonTransform;

    public void FireWeapon()
    {
        GameObject projectile = Instantiate(singularityBall, cannonTransform.position, Quaternion.identity) as GameObject;

        projectile.GetComponent<SingularityProjectileScript>().Fire(cannonTransform.forward);
    }
}
