using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider1 : MonoBehaviour
{
    public bool slider_aktif_yukarı;
    public float hiz;
    public Slider slider_asansor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(slider_aktif_yukarı == true)
            {
            slider_asansor.value += Time.deltaTime * hiz;
            if (slider_asansor.value == slider_asansor.maxValue)
            { slider_aktif_yukarı = false; }

        }



        if (slider_aktif_yukarı == false)
        {
            slider_asansor.value = slider_asansor.minValue;
            
            slider_aktif_yukarı = true; 

        }
    }
}
