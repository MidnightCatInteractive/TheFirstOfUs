using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    
    public AudioClip[] musicTracks;
    private int currentTrackIndex = 0;

    void PlayTrack()
    {
        GetComponent<AudioSource>().clip = musicTracks[currentTrackIndex];
        GetComponent<AudioSource>().Play();
    }

    void PlayNextTrack()
    {
        currentTrackIndex++;
        if(currentTrackIndex >= musicTracks.Length)
        {
            currentTrackIndex = 0;
        }

        PlayTrack();

    }

    void Start()
    {
        PlayTrack();
    }
    void Update()
    {
        if(!GetComponent<AudioSource>().isPlaying)
        {
            PlayNextTrack();
        }
        
    }
}
