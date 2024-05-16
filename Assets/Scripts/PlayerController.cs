using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 20;
    public float leftLimit;
    public float rightLimit;
    public Rigidbody rb;
    public MeshRenderer meshRenderer;
    public float horizontalMultiplier = 2;
    public int redEnergyPoints = 0;
    public int blueEnergyPoints = 0;
    public int greenEnergyPoints = 0;
    public int Score = 0;
    public float raycastDistance = 100f;
    public LayerMask objectsToRemove; //aka obstacles to remove
    public bool greenPowerIsActive = false; //to check whether the green power is activated but haven't been used yet
    public bool bluePowerIsActive = false;
    public bool redPowerIsActive = false;
    public bool isPaused = false;
    public bool uButtonIsPressed = false;
    public bool isGameOver = false;


    public GameObject PausePanel;
    public GameObject GameOverPanel;


    public AudioSource musicAudioSource;
    public AudioSource musicCurrentlyPlayingSource;
    public AudioClip mainMenuBGMusic;
    public AudioClip gameBGMusic;
    public AudioClip gameOverMusic;

    public AudioSource sfxControl;
    public AudioClip switchingFormsSFX;
    public AudioClip invalidActionSFX;
    public AudioClip activatePowerupSFX;


    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI redEnergyPtsText;
    public TextMeshProUGUI blueEnergyPtsText;
    public TextMeshProUGUI greenEnergyPtsText;
    public TextMeshProUGUI gameOvertext;

    


    float horizontalInput;
    bool alive = true;
    



    // Start is called before the first frame update
    void Start()
    {
        musicAudioSource.clip = gameBGMusic;
        musicAudioSource.Play();
        //backgrounMusicControl.Play();
        meshRenderer = this.GetComponent<MeshRenderer>();
        

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(redEnergyPoints == 0 && blueEnergyPoints == 0 && greenEnergyPoints == 0)
        {
            meshRenderer.material.color = new Color(1, 1, 1);
        }

        //j is red
        if (Input.GetKeyDown(KeyCode.J))
        {
            if(redEnergyPoints == 5)
            {
                sfxControl.clip = switchingFormsSFX;
                sfxControl.Play();

                if (bluePowerIsActive || greenPowerIsActive)
                {
                    bluePowerIsActive = false;
                    greenPowerIsActive = false;
                }

                meshRenderer.material.color = new Color(0.8f, 0, 0);
                redEnergyPoints--;
                redEnergyPtsText.text = "RED: " + redEnergyPoints;

            }
            else
            {
                sfxControl.clip = invalidActionSFX;
                sfxControl.Play();
            }
        }
        //k is green
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (greenEnergyPoints == 5)
            {
                sfxControl.clip = switchingFormsSFX;
                sfxControl.Play();

                if (bluePowerIsActive)
                {
                    bluePowerIsActive = false;
                }

                meshRenderer.material.color = new Color(0, 0.8f, 0);
                greenEnergyPoints--;
                greenEnergyPtsText.text = "GREEN: " + greenEnergyPoints;
            }
            else
            {
                sfxControl.clip = invalidActionSFX;
                sfxControl.Play();
            }
        }
        //l is blue 
        else if (Input.GetKeyDown(KeyCode.L))
        {
            if(greenPowerIsActive)
            {
                greenPowerIsActive = false;
            }

            if (blueEnergyPoints == 5)
            {

                sfxControl.clip = switchingFormsSFX;
                sfxControl.Play();
                
                meshRenderer.material.color = new Color(0, 0, 0.8f);
                blueEnergyPoints--;
                blueEnergyPtsText.text = "BLUE: " + blueEnergyPoints;
                
            }
            else
            {
                sfxControl.clip = invalidActionSFX;
                sfxControl.Play();
            }
        }
        //activate powers
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if(meshRenderer.material.color.r == 1 && meshRenderer.material.color.g == 1 && meshRenderer.material.color.b == 1)
            {
                //add sound of failure or error
                //Debug.Log("i'm in normal form no power!");
                sfxControl.clip = invalidActionSFX;
                sfxControl.Play();
            }
            else if (meshRenderer.material.color.r == 0.8f && meshRenderer.material.color.g == 0 && meshRenderer.material.color.b == 0)
            {
               // Debug.Log("dakhalt fel red power");
                if (redEnergyPoints > 0)
                {
                    sfxControl.clip = activatePowerupSFX;
                    sfxControl.Play();

                    redEnergyPoints--;
                    
                    redPowerIsActive = true;
                    //Debug.Log("dakhalt red power: "+ redPowerIsActive);
                    GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
                    foreach (GameObject ostacle in obstacles)
                    {
                        Destroy(ostacle);
                    }
                    redEnergyPtsText.text = "RED: " + redEnergyPoints;
                    // Debug.Log("redEnergyPoints: "+ redEnergyPoints);
                    //do the red functionality

                    /*Ray ray = new Ray(transform.position, transform.forward);
                    if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance))
                    {
                        GameObject objectHit = hit.collider.gameObject;

                        // Check if the detected object has the specified tag.
                       if (objectHit.CompareTag("Obstacle") || objectHit.CompareTag("Orb"))
                        {
                            // If the detected object has the specified tag, remove it.
                            Destroy(objectHit);
                        }
                    }*/

                    /*Ray ray = new Ray(transform.position, transform.forward);

                    // Perform the raycast to detect objects.
                    RaycastHit[] hits = Physics.RaycastAll(ray, raycastDistance);

                    foreach (RaycastHit hit in hits)
                    {
                        GameObject objectHit = hit.collider.gameObject;

                        // Check if the detected object has the specified tags ("Obstacle" or "Orb").
                        if (objectHit.CompareTag("Obstacle") || objectHit.CompareTag("Orb"))
                        {
                            // If the detected object has the specified tag, remove it.
                            Destroy(objectHit);
                        }
                    }*/

                    //check if in form and energy point are 0 then switch to white
                    if (redEnergyPoints == 0)
                    {
                        meshRenderer.material.color = new Color(1, 1, 1);
                    }
                }
                else if(redEnergyPoints == 0)
                {
                    meshRenderer.material.color = new Color(1, 1, 1);
                }
            }
            else if (meshRenderer.material.color.r == 0 && meshRenderer.material.color.g == 0.8f && meshRenderer.material.color.b == 0)
            {
                
                if (greenEnergyPoints > 1)
                {

                    if(!greenPowerIsActive)
                    {
                        sfxControl.clip = activatePowerupSFX;
                        sfxControl.Play();

                        greenEnergyPoints--;
                        greenPowerIsActive = true;
                        greenEnergyPtsText.text = "GREEN: " + greenEnergyPoints;
                        //do the green functionality
                        

                        //check if in form and energy point are 0 then switch to white
                       /* if (greenEnergyPoints == 0)
                        {
                            meshRenderer.material.color = new Color(1, 1, 1);
                        }*/
                    }
                    
                }
                else if (greenEnergyPoints == 1)
                {
                    greenEnergyPoints--;
                    meshRenderer.material.color = new Color(1, 1, 1);
                }
            }
            else if (meshRenderer.material.color.r == 0 && meshRenderer.material.color.g == 0 && meshRenderer.material.color.b == 0.8f)
            {
                if (blueEnergyPoints > 1 && !bluePowerIsActive)
                {
                    sfxControl.clip = activatePowerupSFX;
                    sfxControl.Play();

                    blueEnergyPoints--;
                    blueEnergyPtsText.text = "BLUE: " + blueEnergyPoints;
                    //do the blue functionality
                    //activate shield
                    bluePowerIsActive = true;

                    //check if in form and energy point are 0 then switch to white
                    /*if (blueEnergyPoints == 0)
                    {
                        meshRenderer.material.color = new Color(1, 1, 1);
                    }*/
                }
                else if (blueEnergyPoints == 1 && !bluePowerIsActive)
                {
                    blueEnergyPoints--;
                    meshRenderer.material.color = new Color(1, 1, 1);
                }
            }
        }
        //do pause and resume
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isGameOver)
            {
                if (isPaused)
                {

                    Resume();
                    isPaused = false;
                }
                else
                {

                    Pause();
                    isPaused = true;
                }
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            if(uButtonIsPressed)
            {
                uButtonIsPressed = false;
            }
            else
            {
                uButtonIsPressed = true;
            }
        }
        else if(Input.GetKeyDown(KeyCode.I))
        {
            //red
            if(redEnergyPoints < 5)
            {
                redEnergyPoints++;
                redEnergyPtsText.text = "RED: " + redEnergyPoints;
            }
            else
            {
                sfxControl.clip = invalidActionSFX;
                sfxControl.Play();
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            //green
            if (greenEnergyPoints < 5)
            {
                greenEnergyPoints++;
                greenEnergyPtsText.text = "GREEN: " + greenEnergyPoints;
            }
            else
            {
                sfxControl.clip = invalidActionSFX;
                sfxControl.Play();
            }
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            //blue
            if (blueEnergyPoints < 5)
            {
                blueEnergyPoints++;
                blueEnergyPtsText.text = "BLUE: " + blueEnergyPoints;
            }
            else
            {
                sfxControl.clip = invalidActionSFX;
                sfxControl.Play();
            }
        }
    }

    private void FixedUpdate()
    {
        if(!alive)
        {
            return; 
        }

        Vector3 forwardMove = transform.forward * (speed + 2) * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput *speed * Time.fixedDeltaTime * horizontalMultiplier;
        //Debug.Log("horizontalMove: " + horizontalMove);
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    public void Pause()
    {
        //backgrounMusicControl.Stop();
        musicAudioSource.clip = mainMenuBGMusic;
        musicAudioSource.Play();
        isPaused = true;
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        musicAudioSource.clip = gameBGMusic;
        musicAudioSource.Play();
        //backgrounMusicControl.Play();
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        //backgrounMusicControl.Stop();
        musicAudioSource.clip = gameOverMusic;
        musicAudioSource.Play();
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoadMainMenu()
    {

        
        SceneManager.LoadScene("MainMenu");
        

    }

    public void Die()
    {
        //alive = false;

        //restart the game
        Invoke("Restart",1);
    }

    public void Restart()
    {
        //isPaused = false;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene("MyScene");
    }

  
}
