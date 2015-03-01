using UnityEngine;
using System.Collections;

public class AIWeaponControl : MonoBehaviour {
    private WeaponFiring weaponScript;
    private AISpaceShipController aiInfo;

    public float weaponDelay = 0.25f;

    private float timeSinceLastFire = 0f;

    private bool canFire = true;

	// Use this for initialization
	void Start () {
        weaponScript = this.GetComponent<WeaponFiring>();
        aiInfo = this.GetComponent<AISpaceShipController>();
	}
	
	// Update is called once per frame
	void Update () {
        HandleFireTiming();
        ExecuteLogic();
	}

    private void ExecuteLogic()
    {
        if (aiInfo.HasTarget())
        {
            if (aiInfo.ShouldFire())
            {
                if (canFire)
                {
                    weaponScript.FireWeapon();
                    canFire = false;
                    timeSinceLastFire = 0f;
                }
            }
        }
    }

    private void HandleFireTiming()
    {
        if (!canFire)
        {
            timeSinceLastFire += Time.deltaTime;
        }
        if (timeSinceLastFire >= weaponDelay && !canFire)
        {
            canFire = true;
        }
    }
}
