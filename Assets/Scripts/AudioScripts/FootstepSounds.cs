using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSounds : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    private AudioSource audioSource;
    private int lastIndex = -1;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isMoving = (horizontal != 0 || vertical != 0);

        if(isMoving && !audioSource.isPlaying)
        {
            int randomIndex = GetNextIndex();
            audioSource.PlayOneShot(footstepSounds[randomIndex]);
            lastIndex = randomIndex;
        }
    }

    private int GetNextIndex()
    {
        int nextIndex = Random.Range(0, footstepSounds.Length);
        while(nextIndex == lastIndex)
        {
            nextIndex = Random.Range(0, footstepSounds.Length);
        }
        return nextIndex;
    }

}
