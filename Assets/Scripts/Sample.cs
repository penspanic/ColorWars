using UnityEngine;
using System.Collections;

public class Sample : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Input.GetAxis("Horizontal1") * Vector3.right);
	}
}
