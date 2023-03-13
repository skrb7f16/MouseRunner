using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public SoundScript[] sounds;
    void Start()
    {
        foreach(SoundScript s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.isLoop;
        }
        PlaySound("theme");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlaySound(string name)
    {
        foreach (SoundScript s in sounds)
        {
            if (s.name == name) s.source.Play();
        }
    }
}
