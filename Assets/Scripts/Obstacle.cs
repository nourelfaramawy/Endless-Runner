using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerController playerController;
    public TextMeshProUGUI finalScoreText;
    public Collider obstacleCollider;

    public AudioClip obstacleCollisionSFX;
    public AudioClip obstacleCollisionWithShieldSFX;



    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        obstacleCollider = GetComponent<Collider>();
    }

    public void OnCollisionEnter(Collision collision)
    {
       
        if(collision.gameObject.name == "Player")
        {
            //kill the player 
            //playerController.Die();
            //get player color to check if the player is in any form or not
            Color playerColor = playerController.GetComponent<MeshRenderer>().material.color;
            //Debug.Log("playerColor: " + playerColor);

            if (playerController.uButtonIsPressed)
            {
                obstacleCollider.enabled = false;
            }
            //if i have the blue power activated
            else if (playerController.bluePowerIsActive)
            {
                //playerController.sfxControl.clip = obstacleCollisionWithShieldSFX;
                //playerController.sfxControl.Play();
                // Destroy(gameObject);
                //Debug.Log("dakhalt blue is active");
                //Debug.Log("playerController.bluePowerIsActive: before "+ playerController.bluePowerIsActive);

                playerController.bluePowerIsActive = false;
                //Debug.Log("playerController.bluePowerIsActive: after " + playerController.bluePowerIsActive);
            }
            else if(playerColor.r == 0.8f || playerColor.g == 0.8f || playerColor.b == 0.8f)
            {
                playerController.sfxControl.clip = obstacleCollisionWithShieldSFX;
                playerController.sfxControl.Play();

                //Debug.Log("dakhalt i have color");
                playerController.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
            }
            else
            {
                playerController.sfxControl.clip = obstacleCollisionSFX;
                playerController.sfxControl.Play();

                //game ends and display game over 
                //Debug.Log("game over");
                playerController.isGameOver = true;
                playerController.gameOvertext.text = "SCORE: " + playerController.Score;
                playerController.GameOver();
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
