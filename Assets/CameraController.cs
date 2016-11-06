using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Terrain myTerrain;
    RandomizeNewTerrain obj;
    private Vector3 offset;
    float height;
    float delta = 10.0f;
    // Use this for initialization
    void Start ()
    {
        //calculate current height of landscape at camera center
        height = myTerrain.SampleHeight(transform.position);
        //calculate new offset for camera = current position of the camera + the position of the terrain
        Debug.Log("position:"+transform.position);
        offset = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
        Debug.Log("height of terrain" + height);
        Debug.Log("offset b/t camera and x-z plane" + offset);
        transform.position += offset;
        Debug.Log("final position:" + transform.position);
    }

   
    void setBackToOrigin()
    {
        transform.position = new Vector3(0, Terrain.activeTerrain.SampleHeight(transform.position) + 10.0f, 0);
    }

    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        //Debug.Log("Horizontal:" + moveHorizontal);
        float moveVertical = Input.GetAxis("Vertical");
        //Debug.Log("Vertical:" + moveVertical);
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.position += movement;
        if (moveVertical != 0 || moveHorizontal != 0)
        {
            //float xpos = transform.position.x;
            //float zpos = transform.position.z;
            //float newYPos = Terrain.activeTerrain.SampleHeight(transform.position) + 10.0f;
            //Debug.Log("terrain height" + Terrain.activeTerrain.SampleHeight(transform.position));
            
            transform.position = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position) + 10.0f, transform.position.z);
        }

        if (transform.position.x < -500 || transform.position.x > 500)
        {
            setBackToOrigin();
            obj.RandomizeTerrain();
        }

        if (transform.position.z < -500 || transform.position.z > 500)
        {
            setBackToOrigin();
            obj.RandomizeTerrain();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            setBackToOrigin();
        }
    }
}
