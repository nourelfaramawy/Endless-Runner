using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    
    PlayerController playerController;
    public MeshRenderer meshRenderer;

    public AudioClip collectingOrbSFX;

    public float turnSpeed = 90f;

    // Get the color from the material of the MeshRenderer.
   

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        meshRenderer = this.GetComponent<MeshRenderer>();

    }


    public void OnCollisionEnter(Collision collision)
    {



        if (collision.gameObject.name == "Player")
        {
            playerController.sfxControl.clip = collectingOrbSFX;
            playerController.sfxControl.Play();

            //we'll need to check the color and increase the player's score and the
            //corresponding energy points
            //Debug.Log("dakhalt el collision");
            Color objectColor = meshRenderer.material.color;
            Color playerColor = playerController.GetComponent<MeshRenderer>().material.color;
            //Debug.Log("object color: " + objectColor);
            bool isRed = objectColor.r == 0.8f && objectColor.g < 0.8f && objectColor.b < 0.8f;
            bool isGreen = objectColor.g == 0.8f && objectColor.r < 0.8f && objectColor.b < 0.8f;
            bool isBlue = objectColor.b == 0.8f && objectColor.r < 0.8f && objectColor.g < 0.8f;

            if(isRed)
            {
                //Debug.Log("dakhalt");
                //checking if the player is already red then increase score by 2
                if(playerColor.r == 0.8f)
                {
                    playerController.Score += 2;
                   /* if (playerController.redEnergyPoints < 5)
                    {
                        //playerController.redEnergyPoints++;
                        
                        playerController.redEnergyPoints++;
                    }*/
                }
                else
                {
                    if (playerController.greenPowerIsActive && playerController.redEnergyPoints < 5)
                    {
                        
                        playerController.Score += 5;
                        playerController.redEnergyPoints += 2;

                        if (playerController.redEnergyPoints > 5)
                        {
                            playerController.redEnergyPoints = 5;
                        }
                        playerController.greenPowerIsActive = false;
                    }
                    else
                    {
                        playerController.Score++;

                        if (playerController.redEnergyPoints < 5)
                        {
                            playerController.redEnergyPoints++;

                        }
                    }

                }

            }
            if(isGreen)
            {
                if (playerColor.g == 0.8f)
                {
                    if(playerController.greenPowerIsActive)
                    {
                        //Debug.Log("playerController.Score before: " + playerController.Score);
                        playerController.Score += 10;
                        //Debug.Log("playerController.Score after: " + playerController.Score);
                        
                        playerController.greenPowerIsActive = false;
                    }
                    else
                    {
                        playerController.Score += 2;
                       /* if (playerController.greenEnergyPoints < 5)
                        {
                            //playerController.redEnergyPoints++;
                        
                            playerController.greenEnergyPoints++;
                        }*/
                    }
                   
                }
                else
                {
                    playerController.Score++;

                    if (playerController.greenEnergyPoints < 5)
                    {
                        playerController.greenEnergyPoints++;
                        
                        
                    }
                }
            }
            if(isBlue)
            {
                if (playerColor.b == 0.8f)
                {
                    playerController.Score += 2;

                    /*if (playerController.blueEnergyPoints < 5)
                    {
                        //playerController.redEnergyPoints++;
                        
                        playerController.blueEnergyPoints++;
                    }*/
                }
                else
                {
                    if (playerController.greenPowerIsActive && playerController.blueEnergyPoints < 5)
                    {
                        playerController.Score += 5;
                        playerController.blueEnergyPoints += 2;
                        if(playerController.blueEnergyPoints > 5)
                        {
                            playerController.blueEnergyPoints = 5;
                        }
                        playerController.greenPowerIsActive = false;
                    }
                    else
                    {
                        playerController.Score++;

                        if (playerController.blueEnergyPoints < 5)
                        {
                            playerController.blueEnergyPoints++;

                        }
                    }
                    
                }
            }

            //destroy pill
            Destroy(gameObject);
            playerController.scoreText.text = "SCORE: " + playerController.Score;
            playerController.redEnergyPtsText.text = "RED: " + playerController.redEnergyPoints;
            playerController.greenEnergyPtsText.text = "GREEN: " + playerController.greenEnergyPoints;
            playerController.blueEnergyPtsText.text = "BLUE: " + playerController.blueEnergyPoints;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
