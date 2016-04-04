using UnityEngine;
using System.Collections;

public class Glen_Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(Input.GetAxis("Horizontal")*0.2f, 0f, Input.GetAxis("Vertical") * 0.2f);
	}
}
