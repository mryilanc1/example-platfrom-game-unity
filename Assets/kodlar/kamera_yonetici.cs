using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera_yonetici : MonoBehaviour
{

    public Transform oyuncu;
    public float kamera_hız;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (oyuncu != null)
        transform.position =  Vector3.Slerp (transform.position,new Vector3 (oyuncu.position.x, oyuncu.position.y, transform.position.z),kamera_hız);
    }
}
