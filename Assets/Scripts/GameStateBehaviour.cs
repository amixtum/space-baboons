using UnityEngine;
using System.Collections;

public class GameStateBehaviour : MonoBehaviour {
    public GameObject spaceShip;

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;

	// Use this for initialization
	void Start () {
        defaultPosition = spaceShip.transform.position;
        defaultRotation = spaceShip.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Restart();
        }
	}

    public void Restart()
    {
        spaceShip.transform.position = defaultPosition;
        spaceShip.transform.rotation = defaultRotation;
        spaceShip.rigidbody.Sleep();
        spaceShip.rigidbody.WakeUp();
    }
}
