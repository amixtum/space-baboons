using UnityEngine;
using System.Collections;

public class LaserBehaviour : MonoBehaviour {
    private float lifetime = 0.1f;
    private float aliveFor = 0f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        aliveFor += Time.deltaTime;
        if (aliveFor >= lifetime)
        {
            Destroy(this.gameObject);
        }
	}
}
