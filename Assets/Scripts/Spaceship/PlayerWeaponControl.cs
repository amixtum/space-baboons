using UnityEngine;
using System.Collections;

public class PlayerWeaponControl : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        HandleInput();
	}

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            this.GetComponent<WeaponFiring>().FireWeapon();
        }
    }
}
