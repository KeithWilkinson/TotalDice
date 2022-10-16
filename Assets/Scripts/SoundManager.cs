using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip pressSound;
    private AudioSource audSrc;

    // Start is called before the first frame update
    void Start()
    {
        audSrc = GetComponent<AudioSource>();
    }

    public void PlayPressSound()
    {
        audSrc.PlayOneShot(pressSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
