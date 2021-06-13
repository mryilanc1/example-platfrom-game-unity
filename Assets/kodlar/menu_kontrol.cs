using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu_kontrol : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject oyunmenusu, pausemenu,kaybetme;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void oyun_sahnesine()
    {
        SceneManager.LoadScene(1);
        veri_yoneticisi.veri_olusum.degeri_sıfırlama();
        

    }

    public void duraklat()
    {
        Time.timeScale = 0;
        oyunmenusu.SetActive(false);
        pausemenu.SetActive(true);


    }

    public void oyun_Devam ()
    {
        Time.timeScale = 1;
        
        pausemenu.SetActive(false);
        oyunmenusu.SetActive(true);

    }


    public void tekar_oyna()
    {
        veri_yoneticisi.veri_olusum.bilgi_kaydı();
        
        Time.timeScale = 1;
        
        SceneManager.LoadScene(1);
        veri_yoneticisi.veri_olusum.degeri_sıfırlama();

    }

   

    public void ana_menu()
    {
        veri_yoneticisi.veri_olusum.bilgi_kaydı();
       
        Time.timeScale = 1;
        
        SceneManager.LoadScene(0);

    }

    public void kaybetme_kapatma()
    {
        kaybetme.SetActive(false);
        Time.timeScale = 1;

    }
}
