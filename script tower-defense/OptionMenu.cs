using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionMenu : MonoBehaviour
{
    public AudioSource audio;
    public Slider slider;
    public TextMeshProUGUI txtVolume;


    // Start is called before the first frame update
    private void Start()=> SliderChange();
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SliderChange()
    {
        audio.volume = slider.value;
        txtVolume.text = "Volume" +(audio.volume * 100).ToString("00") + "%";
    }





}
