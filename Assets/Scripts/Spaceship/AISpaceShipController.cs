using UnityEngine;
using System.Collections;

public class AISpaceShipController : MonoBehaviour {
    private SpaceshipMovement movementScript;

    public GameObject target;

    public float minimumThrustRadius = 60f;
    public float minimumFireRadius = 15f;
    public float rotationError = 15f;

	// Use this for initialization
	void Start () {
        movementScript = this.GetComponent<SpaceshipMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        ExecuteLogic();
	}

    private void ExecuteLogic()
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
