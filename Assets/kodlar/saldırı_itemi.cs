using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saldırı_itemi : MonoBehaviour
{
    public float saldırı_zarar, var_sure;
    void Start()
    {
        Destroy(this.gameObject, var_sure);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
