using UnityEngine;
using System.Collections;

public class Trees : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Create floor
		var cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		cube.transform.localScale = new Vector3 (20f, 0.1f, 20f);
		cube.renderer.material.color = new Color (0.3f, 0.4f, 0.3f);
		
		// Create sphere
		var sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.transform.position = new Vector3 (0, 2f, 0);
		sphere.renderer.material.color = new Color (0.3f, 0.6f, 1f);
		sphere.AddComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
