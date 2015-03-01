using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AISpaceShipController : MonoBehaviour {
    private SpaceshipMovement movementScript;

    private List<GameObject> spaceships = new List<GameObject>();

    private GameObject target;

    public float minimumThrustRadius = 60f;
    public float minimumFireRadius = 15f;
    public float rotationError = 15f;

	// Use this for initialization
	void Start () 
    {
        movementScript = this.GetComponent<SpaceshipMovement>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        FindSpaceshipsInScene();

        if (!HasTarget())
        {
            AcquireTarget();
        }

        ExecuteLogic();
	}

    private void FindSpaceshipsInScene()
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
    }

    private GameObject GetNearestSpaceship()
    {
        if (spaceships.Count > 0)
        {
            float distance = Vector3.Distance(this.transform.position, 
                                              spaceships[0].transform.position);

            GameObject closestShip = spaceships[0];
            float closestDistance = distance;

            foreach (GameObject ship in spaceships)
            {
                distance = Vector3.Distance(this.transform.position, ship.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestShip = ship;
                }
            }

            return closestShip;
        }
        return null;
    }

    private void AcquireTarget()
    {
        target = GetNearestSpaceship();
    }

    public bool HasTarget()
    {
        return (target != null);
    }

    private void ExecuteLogic()
    {
        if (HasTarget())
        {
            if (ShouldPitchDown())
            {
                movementScript.PitchDown();
            }
            if (ShouldPitchUp())
            {
                movementScript.PitchUp();
            }
            if (ShouldRollLeft())
            {
                movementScript.RollLeft();
            }
            if (ShouldRollRight())
            {
                movementScript.RollRight();
            }
            if (ShouldThrust())
            {
                movementScript.ForwardThrust();
            }

            AcquireTarget();
        }
    }


    public bool ShouldFire()
    {
        float forwardAngle = GetForwardAngleToTarget();

        return (forwardAngle <= minimumFireRadius);
    }
    public bool ShouldPitchUp()
    {
        float verticalAngle = GetVerticalAngleToTarget();
        float forwardAngle = GetForwardAngleToTarget();

        // In second or third quadrant of vertical rotation
        if (forwardAngle <= 90f)
        {
            if (verticalAngle <= 90f - rotationError)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // In first or fourth quadrant of vertical rotation
        else
        {
            if (verticalAngle <= 90f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public bool ShouldPitchDown() 
    {
        float verticalAngle = GetVerticalAngleToTarget();
        float forwardAngle = GetForwardAngleToTarget();

        // In second or third quadrant of vertical rotation
        if (forwardAngle <= 90f)
        {
            if (verticalAngle >= 90f + rotationError)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // In first or fourth quadrant of vertical rotation
        else
        {
            if (verticalAngle > 90f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public bool ShouldRollRight()
    {
        float forwardAngle = GetForwardAngleToTarget();
        float rightAngle = GetRightAngleToTarget();

        if (forwardAngle > rotationError)
        {
            if (rightAngle <= 90f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public bool ShouldRollLeft()
    {
        float forwardAngle = GetForwardAngleToTarget();
        float rightAngle = GetRightAngleToTarget();

        if (forwardAngle > rotationError)
        {
            if (rightAngle > 90f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public bool ShouldThrust()
    {
        float forwardAngle = GetForwardAngleToTarget();

        return (forwardAngle <= minimumThrustRadius);
    }

    public float GetVerticalAngleToTarget()
    {
        return Vector3.Angle(this.transform.up, GetNormalizedDirectionToTarget());
    }
    public float GetForwardAngleToTarget()
    {
        return Vector3.Angle(this.transform.forward, GetNormalizedDirectionToTarget());
    }
    public float GetRightAngleToTarget()
    {
        return Vector3.Angle(this.transform.right, GetNormalizedDirectionToTarget());
    }

    public Vector3 GetNormalizedDirectionToTarget()
    {
        return (target.transform.position - this.transform.position).normalized;
    }
    public Vector3 GetDisplacementVectorToTarget()
    {
        return (target.transform.position - this.transform.position);
    }
}
