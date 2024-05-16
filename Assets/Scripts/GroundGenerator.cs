using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject groundTile;

    Vector3 nextSpawnPoint;


    public void spawntile()
    {
        //what we want to spawn, the position, and the rotation 

        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++) {
            spawntile();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
