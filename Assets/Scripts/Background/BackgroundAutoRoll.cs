using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundAutoRoll : MonoBehaviour
{
    public float m_repeatCircleT = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, Time.time / m_repeatCircleT);
    }
}
