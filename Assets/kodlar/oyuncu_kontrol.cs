using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncu_kontrol : MonoBehaviour
{
    Animator animasyoncu;
    
    Rigidbody2D oyuncu_fizik;
    public float oyuncu_hız =1;
    public float ziplama_hizi = 11f, ziplama_sikligi=1f ,bi_sonraki_sıplama_ = 1f;
    
   

    public bool zemine_Degdi, zemine_Degdi2 = false;
    bool yuz_bakis_sag = true;

    public Transform zemin_kontrol_objesi_konum, zemin_kontrol_objesi_konum2;
    public float zemin_kontolobjesi_capi, zemin_kontolobjesi_capi2;
    public LayerMask zeminkontrol_Layer;


    void Start()
    {
        oyuncu_fizik = GetComponent<Rigidbody2D>();
        animasyoncu = GetComponent<Animator>();
    }

    
    void Update()
    {
        yatay_hareket();
        zemin_degme_kontrol();

        if (Input.GetAxis("Vertical") > 0.01f && (zemine_Degdi || zemine_Degdi2) && (bi_sonraki_sıplama_ < Time.timeSinceLevelLoad))
        {
            bi_sonraki_sıplama_ = Time.timeSinceLevelLoad + ziplama_sikligi;

            Debug.Log(Input.GetAxis("Vertical"));

            ziplama();

        }

        if(oyuncu_fizik.velocity.x <0 && yuz_bakis_sag)
        {

            yuz_cevirme();
        }

        else if (oyuncu_fizik.velocity.x > 0 && !yuz_bakis_sag)
        {
            yuz_cevirme(); 
        }
    
    }

 
    void yatay_hareket()
    {
        oyuncu_fizik.velocity = new Vector2(Input.GetAxis("Horizontal") * oyuncu_hız, oyuncu_fizik.velocity.y);
        animasyoncu.SetFloat("Oyuncu_hız", Mathf.Abs (oyuncu_fizik.velocity.x));

    }

    void yuz_cevirme()
    {
        yuz_bakis_sag = !yuz_bakis_sag;
        Vector3 yerel_scale_degeri = transform.localScale;
        yerel_scale_degeri.x *= -1;
        transform.localScale = yerel_scale_degeri;

    }


    void ziplama()
    {
        oyuncu_fizik.AddForce(new Vector2(0f, ziplama_hizi));


    }


    void zemin_degme_kontrol()
    {
        zemine_Degdi = Physics2D.OverlapCircle(zemin_kontrol_objesi_konum.position, zemin_kontolobjesi_capi, zeminkontrol_Layer);
        zemine_Degdi2 = Physics2D.OverlapCircle(zemin_kontrol_objesi_konum2.position, zemin_kontolobjesi_capi2, zeminkontrol_Layer);
        animasyoncu.SetBool("zemine_Degdi_anim", (zemine_Degdi || zemine_Degdi2));


    }
}
