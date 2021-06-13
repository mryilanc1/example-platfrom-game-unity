using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class anamenu_kontrol : MonoBehaviour
{
    public GameObject skorveri, hakkinda_uı;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void skor_acım_button()
    {
        veri_yoneticisi.veri_olusum.bilgi_cekimi();
        skorveri.transform.GetChild(0).GetComponent<Text>().text = "Toplam Atılan Saldırı İtemi : " + veri_yoneticisi.veri_olusum.toplam_atıtan_saldırı_item.ToString();
        skorveri.transform.GetChild(1).GetComponent<Text>().text = "Toplam Öldürülen Düşman: "+ veri_yoneticisi.veri_olusum.toplam_oldurulen_dusman.ToString();
        skorveri.SetActive(true);
    }

    public void skor_kapama_button()
    {
        skorveri.SetActive(false);

    }

    public void hakkinda()
    {
        hakkinda_uı.SetActive(true);

    }


    public void hakkinda_kapama()
    {
        hakkinda_uı.SetActive(false);

    }

}
