using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudio : MonoBehaviour
{

    public bool isMuted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void muteAllAudio(bool mute)
    {
        if(mute)
        {
            AudioListener.volume = 0f;
            isMuted = true;
        }
        else
        {
            
            AudioListener.volume = 1;
            isMuted = false;

        }
    }
}
