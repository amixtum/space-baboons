using UnityEngine;
using System.Collections;

public class SingularityProjectileScript : MonoBehaviour {
    public float impulseForce = 100f;
    public float lifetime = 5f;
    public float lifeAfterCollision = 0.2f;
    public float gravityRadius = 100f;
    public float gravityForce = 100f;

    private float timeAlive = 0f;

    private bool hasCollided = false;

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
            Destroy(this.gameObject);
        }
    }

    private void TimedCollisionDestruction()
    {
        timeAlive += Time.deltaTime;

        if (timeAlive >= lifeAfterCollision)
        {
            Destroy(this.gameObject);
        }
    }

    private void ApplyGravityNearSphere()
    {
        RaycastHit[] objectsInSphere;

        objectsInSphere = Physics.SphereCastAll(this.transform.position, gravityRadius, this.transform.right, 1000);

        if (objectsInSphere.Length > 0)
        {
            foreach (RaycastHit hit in objectsInSphere)
            {
                if (hit.collider.gameObject != this.gameObject)
                {
                    GameObject objectHit = hit.collider.gameObject;

                    if (objectHit.tag == "has_info")
                    {
                        ObjectInfo info = objectHit.GetComponent<ObjectInfo>();

                        if ((info.GetObjectType() & ObjectInfo.ObjectType.Gravity) != 0)
                        {
                            Vector3 directionToSphere = (this.transform.position - objectHit.transform.position).normalized;
                            objectHit.rigidbody.AddForce(directionToSphere * gravityForce,ForceMode.Impulse);
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
