using UnityEngine;
using System.Collections;

public class CameraLogic : MonoBehaviour {
    public GameObject spaceship;
    public Vector3 relativePosition;
    public float catchUpSpeed = 0.5f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        AutoCam();
        
	}

    private void AutoCam()
    {
        Vector3 relative_to_world = spaceship.transform.TransformPoint(relativePosition);

        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, relative_to_world, catchUpSpeed);

        Camera.main.transform.rotation = spaceship.transform.rotation;

        //Camera.main.transform.LookAt(spaceship.transform);
    }

    private void MouseCam()
    {

    }
}
