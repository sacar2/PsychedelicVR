using UnityEngine;
using System.Collections;
using System;
public class RandomizeNewTerrain : MonoBehaviour {
    public Color colorStart = Color.red;
    public Color colorEnd = Color.green;
    public float duration = 1.0F;
    float lerp;
    public Renderer rend;
    public CameraController camera;
    public Texture[] textures;
    public int currentTexture;
    //Random.seed = 50;
    

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
    }
    public void RandomizeTerrain()
    {
        System.Random rand = new System.Random();
        float effs = Convert.ToSingle((rand.NextDouble()+.1)*.2);
        GetComponent<TerrainToolkit>().PerlinGenerator(rand.Next(1, 4), effs, rand.Next(1, 3), 1f);
        

    }
    // Update is called once per frame
    void Update () {
        /*if (Input.GetKeyDown(KeyCode.Space))
         {
             Debug.Log(currentTexture + " / " + textures.Length);
             currentTexture = (currentTexture % textures.Length);
             rend.material.mainTexture = textures[currentTexture];
             currentTexture++;
             Debug.Log("texture" + textures[currentTexture].name);
         }*/
        if (transform.position.x < -500 || transform.position.x > 500)
        {
            RandomizeTerrain();
        }

        if (transform.position.z < -500 || transform.position.z > 500)
        {
            RandomizeTerrain();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //Application.LoadLevel(Application.loadedLevel);
            RandomizeTerrain();
        }

        lerp = Mathf.PingPong(Time.time, duration) / duration;
        //Debug.Log("lerp" + lerp);
        rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
    }
    
}