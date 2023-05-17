using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLevelScript : MonoBehaviour
{    
    [SerializeField] public AudioSource _source;
 
    private static AudioSource _globalSource;
 
    public static void PlayAudioLvl()
    {
        _globalSource.Play();
    }

    public static void StopAudioLvl()
    {
        _globalSource.Stop();
    }
 
    private void Awake()
    {
        _globalSource = _source;
    }
}
