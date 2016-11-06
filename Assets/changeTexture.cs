using UnityEngine;
using System.Collections;

public class changeTexture : MonoBehaviour {
    public Texture[] myTextures;
    int maxTextures;
    int arrayPos = 0;
    private Renderer rend;
    public Terrain terrain;

    // Use this for initialization
    void Start () {
        maxTextures = myTextures.Length - 1;
        rend = terrain.GetComponent<Renderer>();
        rend.material.mainTexture = myTextures[0];
        //string keyword = myTextures[0].name.ToUpper();
        //rend.material.EnableKeyword("_NORMALMAP");
        //rend.material.SetTexture("_BumpMap", myTextures[0]);

        Debug.Log("hi"+ myTextures[0].GetType());
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            arrayPos %= myTextures.Length;
            /* if (arrayPos == maxTextures)
             {
                 arrayPos = 0;
             }
             else
             {
                 arrayPos++;
             }*/
            rend.material.mainTexture = myTextures[arrayPos];
           // rend.material.SetTexture(myTextures[3].name, myTextures[3]);
            arrayPos++;

        }
    }
}
