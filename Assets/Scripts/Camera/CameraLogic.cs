using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraLogic : MonoBehaviour {
    private GameObject spaceship;
    public Vector3 relativePosition;
    public float catchUpSpeed = 0.5f;

    private List<GameObject> spaceships = new List<GameObject>();
    private int currentShipIndex = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (spaceships.Count == 0)
        {
            AddSpaceShipsToList();
        }
        else
        {
            AutoCam();
        }
	}

    void Update()
    {
        if (spaceships.Count > 0)
        {
            HandleTargetCycling();
        }
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

    private void HandleTargetCycling()
    {
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            CycleBackTargets();
        }
        if (Input.GetKeyDown(KeyCode.Period))
        {
            CycleForwardTargets();
        }
    }

    private void CycleForwardTargets()
    {
        if (currentShipIndex == spaceships.Count - 1)
        {
            currentShipIndex = 0;
        }
        else
        {
            currentShipIndex++;
        }

        SetTarget(currentShipIndex);
    }
    private void CycleBackTargets()
    {
        if (currentShipIndex == 0)
        {
            currentShipIndex = spaceships.Count - 1;
        }
        else
        {
            currentShipIndex--;
        }

        SetTarget(currentShipIndex);
    }
    private void SetTarget(int shipIndex)
    {
        if (shipIndex < 0 || shipIndex >= spaceships.Count)
        {
            return;
        }
        else
        {
            spaceship = spaceships[shipIndex];
            currentShipIndex = shipIndex;
        }
    }

    private void AddSpaceShipsToList() 
    {
        GameObject[] infoObjects = GameObject.FindGameObjectsWithTag("has_info");

        foreach (GameObject obj in infoObjects)
        {
            ObjectInfo objInfo = obj.GetComponent<ObjectInfo>();

            if ((objInfo.GetObjectType()
                & ObjectInfo.ObjectType.Spaceship)
                != ObjectInfo.ObjectType.None)
            {
                if (!spaceships.Contains(obj) && obj != this.gameObject)
                {
                    spaceships.Add(obj);
                }
            }
        }

        SetTarget(currentShipIndex);
    }
}
