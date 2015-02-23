using UnityEngine;
using System.Collections;

public class ObjectInfo : MonoBehaviour {
    public enum ObjectType
    {
        None = 0,
        Gravity = 1 << 0,
        Spaceship = 1 << 1,
        Projectile = 1 << 2,
        Beam = 1 << 3,
        Static = 1 << 4
    }

    public ObjectType[] types;

    private ObjectType type = ObjectType.None;

    void Start()
    {
        CombineTypes();
    }

    private void CombineTypes()
    {
        foreach (ObjectType t in types)
        {
            type |= t;
        }
    }

    public void SetObjectType(ObjectType type)
    {
        this.type = type;
    }
    public void AddObjectType(ObjectType toAdd)
    {
        type |= toAdd;
    }
    public ObjectType GetObjectType()
    {
        return type;
    }
}
