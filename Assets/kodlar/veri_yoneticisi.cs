using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;
using UnityEngine.SceneManagement;

public class veri_yoneticisi : MonoBehaviour
{
    public static veri_yoneticisi veri_olusum;

    int atıtan_saldırı_item ;
    public int toplam_atıtan_saldırı_item;
    int oldurulen_dusman ;
    public int toplam_oldurulen_dusman;
    EasyFileSave myfile;

    // Start is called before the first frame update
    void Awake()
    {

        if(veri_olusum == null)
        {
            veri_olusum = this;
            baslama_veri_sureci();
        }
        else
        {
            Destroy(gameObject);

        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int saldırı_item_miktar
    {
        get
        {
            return atıtan_saldırı_item;
        }

        set
        {
            atıtan_saldırı_item = value;
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                GameObject.Find("saldırı_item_miktari").GetComponent<Text>().text = "Kullanılan Jilet Miktarı: " + atıtan_saldırı_item.ToString();
            }
        }


    }


    public int dusman_miktari
    {
        get 
        {
            return  oldurulen_dusman;
            
        }

        set
        {
            oldurulen_dusman = value;
            if (SceneManager.GetActiveScene().buildIndex ==1 )
            {
                GameObject.Find("oldurulen_dusman").GetComponent<Text>().text = "Öldürülen Düşman miktarı: " + oldurulen_dusman.ToString();
            }
        }
    }

    public void baslama_veri_sureci()
    {
        myfile = new EasyFileSave();
        bilgi_cekimi();
    }

    public void bilgi_kaydı()
    {

        toplam_atıtan_saldırı_item += atıtan_saldırı_item;
        toplam_oldurulen_dusman += oldurulen_dusman;

        myfile.Add("toplam_item", toplam_atıtan_saldırı_item);
        myfile.Add("toplam_olu_dusman", toplam_oldurulen_dusman);
        myfile.Save();
    }

    public void bilgi_cekimi()
    {
        if ( myfile.Load() )
        {
            toplam_atıtan_saldırı_item = myfile.GetInt("toplam_item");
            toplam_oldurulen_dusman = myfile.GetInt("toplam_olu_dusman");


        }

    }

    public void degeri_sıfırlama()
    {
        dusman_miktari = 0;
        saldırı_item_miktar = 0;
        
    }
}
