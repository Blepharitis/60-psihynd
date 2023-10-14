using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayArrowRightLeft : MonoBehaviour
{
    [SerializeField]
    [EventRef]
    private string soundEvent = null; //Обьявляем чтобы менять

    public void PlaySound()  
    {
        if(soundEvent != null)
        {
            RuntimeManager.PlayOneShot(soundEvent);
        }
    }
}
