using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dusman_manager : MonoBehaviour
{
    public float can;
    public float zarar;
    bool collider_mesgul;
    public Slider Slider;
    
    void Start()
    {
        Slider.maxValue = can;
        Slider.value = can;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Player"  && !collider_mesgul) 

    {
        collider_mesgul = true;
        other.GetComponent<oyunuc_manager>().zarar_alma(zarar);
    }
        else if ( other.tag =="saldırı_item")
        {
            zarar_alma(other.GetComponent<saldırı_itemi>().saldırı_zarar);
            Destroy(other.gameObject);
            
        }

        


    }

    private void OnTriggerExit2D(Collider2D other)
    {

        collider_mesgul = false;
        
    }








    // Update is called once per frame
    void Update()
    {
        

    }

    public void zarar_alma(float zarar)
    {

        if ((can - zarar) >= 0)
        {
            can -= zarar;
        }
        else
        {
            can = 0;
        }
        Slider.value = can;
        olum_var();

    }

    public void olum_var()
    {
        if (can <= 0)

        {
            veri_yoneticisi.veri_olusum.dusman_miktari++;
            Destroy(gameObject);
        }

    }


}
