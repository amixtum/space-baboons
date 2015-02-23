using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gravity : MonoBehaviour {
    private List<GameObject> gravityObjects = new List<GameObject>();

    public float forcePerMassUnit = 50f;
    public float distanceProportionality = 2f;

	// Use this for initialization
	void Start () {
        AddGravityObjectsToList();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        HandleGravity();
	}

    private void AddGravityObjectsToList()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("gravity_object"))
        {
            gravityObjects.Add(obj);
        }
    }

    private void HandleGravity()
    {
        foreach (GameObject obj in gravityObjects)
        {
            foreach (GameObject other in gravityObjects)
            {
                if (obj != other)
                {
                    float distance = (other.transform.position - obj.transform.position).magnitude;
                    Vector3 direction = (obj.transform.position - other.transform.position).normalized;
                    float forceMagnitude = other.rigidbody.mass * obj.rigidbody.mass * (1 / Mathf.Abs(Mathf.Pow(distance, distanceProportionality)));

                    other.rigidbody.AddForce(direction * forceMagnitude * forcePerMassUnit);
                }
            }
        }
    }
}
