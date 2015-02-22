using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateStars : MonoBehaviour {
    public GameObject star;

    public GameObject sun;

    public float xRange = 1000f;
    public float yRange = 1000f;
    public float zRange = 1000f;

    public float minDistance = 1f;
    public float minSunDistance = 1000f;

    public float numToGen = 2000f;
    public float sunsToGen = 100f;

	// Use this for initialization
	void Start () {
        Generate();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void Generate()
    {
        bool finished = false;
        int numGenned = 0;
        List<Vector3> positions = new List<Vector3>();

        while (!finished)
        {
            float randX = Random.Range(-xRange, xRange);
            float randY = Random.Range(-yRange, yRange);
            float randZ = Random.Range(-zRange, zRange);

            Vector3 newPos = new Vector3(randX, randY, randZ);

            bool isUnique = true;

            foreach (Vector3 pos in positions)
            {
                if (Vector3.Distance(newPos, pos) < minDistance)
                {
                    isUnique = false;
                }
            }

            if (isUnique)
            {
                numGenned++;
                positions.Add(newPos);
            }

            if (numGenned == numToGen)
            {
                finished = true;
            }
        }

        foreach (Vector3 pos in positions)
        {
            Instantiate(star, pos, Quaternion.identity);
        }

        positions.Clear();

        finished = false;

        for (int i = 0; i < sunsToGen; ++i)
        {
            float randX = Random.Range(-xRange, xRange);
            float randY = Random.Range(-yRange, yRange);
            float randZ = Random.Range(-zRange, zRange);

            Vector3 newPos = new Vector3(randX, randY, randZ);

            bool isUnique = true;

            foreach (Vector3 pos in positions)
            {
                if (Vector3.Distance(newPos, pos) < minSunDistance)
                {
                    isUnique = false;
                }
            }

            if (isUnique)
            {
                numGenned++;
                positions.Add(newPos);
            }

            if (numGenned == numToGen)
            {
                finished = true;
            }
        }

        foreach (Vector3 pos in positions)
        {
            Instantiate(sun, pos, Quaternion.identity);
        }
    }
}
