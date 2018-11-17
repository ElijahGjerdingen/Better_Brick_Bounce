using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusicVolume : MonoBehaviour {

    public Slider slider;

    //public void Start()
    //{
    //    ChangeVolume(slider.value);
    //}

    public void ChangeVolume()
    {
        AudioListener.volume = slider.value;
    }
}
