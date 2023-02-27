using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpObstacleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float s = 5 / (2 / Time.deltaTime);
        transform.Translate(0, -s, 0);

        if (transform.position.y < -5.5)
            this.gameObject.SetActive(false);
    }
}
