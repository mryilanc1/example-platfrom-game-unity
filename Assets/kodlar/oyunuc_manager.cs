using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class oyunuc_manager : MonoBehaviour
{
    
    public float can, saldırı_hizi;
    Transform saldırı_cikis_noktasi;
    public Transform saldırı_item, canazalma_gorsel, kan_partikul   ;
    bool olum;
    public Animator sandik,sandik2,sandik3;
    bool ui_temas;
    public GameObject kaybet_uı,ustmenu;
    public Text kaybet_text;
    public Text altin_text;
    int altin;

    public Slider oyunuc_slader;
    // Start is called before the first frame update
    void Start()
    {
        oyunuc_slader.maxValue = can;
        oyunuc_slader.value = can;
        saldırı_cikis_noktasi = transform.GetChild(1);
        veri_yoneticisi.veri_olusum.saldırı_item_miktar = 0;
        veri_yoneticisi.veri_olusum.dusman_miktari = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ui_temas = EventSystem.current.currentSelectedGameObject == null;

        if ( Input.GetMouseButtonDown(0) &&  ui_temas)
        {
           
            saldırı();

        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TRİGGER AKTİF ");
        if (other.tag == "dusme_kontrol")
        {
            Destroy(Instantiate(kan_partikul, transform.position, Quaternion.identity), 1f);
            
            

            Debug.Log("TRİGGER İÇİ AKTİF ");
            gameObject.SetActive(false);
            Invoke("gecikme_dus_yenilgi", 1.7f);
            
            
            
        }
        if (other.tag == "sandik")
        {
            Debug.Log("sandik_ trigger");
            sandik.SetBool("sandik", true);
            sandik2.SetBool("sandik", true);
            sandik3.SetBool("sandik", true);


        }

        if (other.tag == "altin")
        {
            altin++;
            Destroy(other.gameObject);
            altin_text.text = ": " + altin.ToString();

        }

    }
    
    void gecikme_dus_yenilgi()
    {

        kaybet_uı.SetActive(true);
        ustmenu.SetActive(false);
        kaybet_text.text = "Aşağı Düştünüz";
        Time.timeScale = 0;
        gameObject.SetActive(false);

    }

    void gecikme_can_yenilgi()
    {

        kaybet_uı.SetActive(true);
        ustmenu.SetActive(false);
        kaybet_text.text = "Öldünüz";
        Time.timeScale = 0;
        gameObject.SetActive(false);

    }


    public void zarar_alma(float zarar )
    {
        Instantiate(canazalma_gorsel, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = zarar.ToString();

        if((can-zarar) >=0 )
        {
            can -= zarar;
        }
        else
        {
            can = 0;
        }
        oyunuc_slader.value = can;
        olum_var();
    }

    public void olum_var()
    {
        if(can <=0)
        {
            Destroy(Instantiate(kan_partikul, transform.position, Quaternion.identity), 1f);
            olum = true;
            gameObject.SetActive(false);
            Invoke("gecikme_can_yenilgi", 1.7f);
        }

    }


    public void saldırı()
    {

        Transform temp_item;
        temp_item = Instantiate(saldırı_item, saldırı_cikis_noktasi.position, Quaternion.identity);
        temp_item.GetComponent<Rigidbody2D>().AddForce(saldırı_cikis_noktasi.forward* saldırı_hizi);
        veri_yoneticisi.veri_olusum.saldırı_item_miktar++;
        ////////////////    05:48 
    }


}
