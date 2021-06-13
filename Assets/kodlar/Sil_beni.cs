using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sil_beni : MonoBehaviour
{
    public float silinme_suresi;

    void Start()
    {
        Destroy(gameObject, silinme_suresi);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
