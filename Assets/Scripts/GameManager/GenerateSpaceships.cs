using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateSpaceships : MonoBehaviour {
    public GameObject heavyFighter;
    public GameObject lightFighter;

    public int numberToGenerate = 10;
    public float minDistanceFromOtherShips = 20f;
    public float generationRadius = 500f;

	// Use this for initialization
	void Start () {
        Generate();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void Generate()
    {
        List<Vector3> positions = new List<Vector3>();
        bool unique;

        while (positions.Count < numberToGenerate)
        {
            Vector3 randomPosition = GetRandomVectorInRadius();

            unique = true;

            foreach (Vector3 v in positions)
            {
                if (Vector3.Distance(v, randomPosition) 
                    <= minDistanceFromOtherShips)
                {
                    unique = false;
                    break;
                }
            }

            if (unique)
            {
                positions.Add(randomPosition);
            }
        }

        foreach (Vector3 v in positions)
        {
            if (Random.value < 0.5f)
            {
                Instantiate(lightFighter, v, Quaternion.identity);
            }
            else 
            {
                Instantiate(heavyFighter, v, Quaternion.identity);
            }
        }
    }

    private Vector3 GetRandomVectorInRadius()
    {
        return Random.insideUnitSphere * generationRadius;
    }
}
