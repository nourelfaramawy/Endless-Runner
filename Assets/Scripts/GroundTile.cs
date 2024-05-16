using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundGenerator groundGenerator;
    PlayerController playerController;

    public GameObject obstaclePrefab;
    public GameObject orbPrefab;



    // Start is called before the first frame update
    void Start()
    {
        groundGenerator = GameObject.FindObjectOfType<GroundGenerator>();
        playerController = GameObject.FindObjectOfType<PlayerController>();

        spawnOsbtacle();
        spawnOrb();
    }

    

    private void OnTriggerExit(Collider other)
    {
        groundGenerator.spawntile();
        //destroy object 2 seconds after the player exits the collider
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnOsbtacle()
    {


        /*int obstacleSpawnIndex = Random.Range(2, 5);
        int obstacleSpawnIndex2;*/

        int obstacleGeneratedPosition1 = Random.Range(2, 5);
        int obstacleGeneratedPosition2;

        do
        {
            obstacleGeneratedPosition2 = Random.Range(2, 5);
        } while (obstacleGeneratedPosition2 == obstacleGeneratedPosition1);

       
        bool generteTwoObstacles = Random.Range(0, 2) == 0;

        Transform spawnPoint = transform.GetChild(obstacleGeneratedPosition1).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);

        if (generteTwoObstacles)
        {
            Transform generatedPoint2 = transform.GetChild(obstacleGeneratedPosition2).transform;
            Instantiate(obstaclePrefab, generatedPoint2.position, Quaternion.identity, transform);
        }



    }

    void spawnOrb()
    {
        
       /* int orbSpawnIndex1 = Random.Range(5, 8);
        int orbSpawnIndex2;
        int orbSpawnIndex3; */

        int orbGeneratedPosition1 = Random.Range(5, 8);
        int orbGeneratedPosition2;
        int orbGeneratedPosition3;

        do
        {
            orbGeneratedPosition2 = Random.Range(5, 8);
        } while (orbGeneratedPosition2 == orbGeneratedPosition1);

        do
        {
            orbGeneratedPosition3 = Random.Range(5, 8);
        } while (orbGeneratedPosition3 == orbGeneratedPosition1 || orbGeneratedPosition3 == orbGeneratedPosition2);


        int numOrbsToSpawn = Random.Range(1, 4);

        for (int i = 0; i < numOrbsToSpawn; i++)
        {
            int orbPosition;

            if (i == 0)
            {
                orbPosition = orbGeneratedPosition1;
            }
            else if (i == 1)
            {
                orbPosition = orbGeneratedPosition2;
            }
            else
            {
                orbPosition = orbGeneratedPosition3;
            }

            Transform spawnPoint = transform.GetChild(orbPosition).transform;
            spawnPoint.position = new Vector3(spawnPoint.position.x, 0.7f, spawnPoint.position.z);
            Color orbColor = randomizeColor();

            GameObject temp = Instantiate(orbPrefab, spawnPoint.position, Quaternion.identity, transform);
            temp.GetComponent<MeshRenderer>().material.color = orbColor;
        }


    }

    /*Color GetRandomColor()
    {
        int colorChoice = Random.Range(1, 4);

        if (colorChoice == 1)
        {
            return new Color(0.8f, 0, 0);
        }
        else if (colorChoice == 2)
        {
            return new Color(0, 0, 0.8f);
        }
        else
        {
            return new Color(0, 0.8f, 0);
        }
    }*/

    Color randomizeColor()
    {
        int chosenColor = Random.Range(1, 4);

        if (chosenColor == 1)
        {
            return new Color(0.8f, 0, 0);
        }
        else if (chosenColor == 2)
        {
            return new Color(0, 0, 0.8f);
        }
        else
        {
            return new Color(0, 0.8f, 0);
        }
    }

}
