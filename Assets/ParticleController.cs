using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

    public Transform cam;
    public Vector3 offset;
    
    // Use this for initialization
    void Start () {
        transform.position = cam.transform.position + offset ;

    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = cam.transform.position + offset;
    }
}
