using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingularityProjectileScript : MonoBehaviour {
    public float impulseForce = 100f;
    public float lifetime = 5f;
    public float lifeAfterCollision = 0.2f;
    public float gravityRadius = 100f;
    public float gravityForce = 100f;

    private GameObject _GameManager;

    private float timeAlive = 0f;

    private bool hasCollided = false;

    void Start()
    {
        _GameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {
        if (!hasCollided)
        {
            PostFireLogic();
        }
        else
        {
            TimedCollisionDestruction();
        }
    }

    void FixedUpdate()
    {
        ApplyGravityNearSphere();
    }

    void OnCollisionEnter(Collision col)
    {
        hasCollided = true;
        timeAlive = 0;
    }

    private void PostFireLogic()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive >= lifetime)
        {
            _GameManager.GetComponent<Gravity>().RemoveFromGravityObjects(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void TimedCollisionDestruction()
    {
        timeAlive += Time.deltaTime;

        if (timeAlive >= lifeAfterCollision)
        {
            _GameManager.GetComponent<Gravity>().RemoveFromGravityObjects(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void ApplyGravityNearSphere()
    {
        List<RaycastHit> objectsInSphere = new List<RaycastHit>();

        RaycastHit[] rightSweep;
        RaycastHit[] leftSweep;
        RaycastHit[] upSweep;
        RaycastHit[] downSweep;

        rightSweep = Physics.SphereCastAll(this.transform.position, gravityRadius, this.transform.right, 100);
        leftSweep = Physics.SphereCastAll(this.transform.position, gravityRadius, -this.transform.right, 100);
        upSweep = Physics.SphereCastAll(this.transform.position, gravityRadius, this.transform.up, 100);
        downSweep = Physics.SphereCastAll(this.transform.position, gravityRadius, -this.transform.up, 100);

        objectsInSphere.AddRange(rightSweep);
        objectsInSphere.AddRange(leftSweep);
        objectsInSphere.AddRange(upSweep);
        objectsInSphere.AddRange(downSweep);

        if (objectsInSphere.Count > 0)
        {
            foreach (RaycastHit hit in objectsInSphere)
            {
                if (hit.collider.gameObject != this.gameObject)
                {
                    GameObject objectHit = hit.collider.gameObject;

                    if (objectHit.tag == "has_info")
                    {
                        ObjectInfo info = objectHit.GetComponent<ObjectInfo>();

                        if ((info.GetObjectType() & ObjectInfo.ObjectType.Gravity) != ObjectInfo.ObjectType.None)
                        {
                            Vector3 directionToSphere = (this.transform.position - objectHit.transform.position).normalized;
                            objectHit.rigidbody.AddForce(directionToSphere * gravityForce);
                        }
                    }
                }
            }
        }
    }

    public void Fire(Vector3 direction)
    {
        this.rigidbody.AddForce(direction * impulseForce, ForceMode.Impulse);
    }
}
