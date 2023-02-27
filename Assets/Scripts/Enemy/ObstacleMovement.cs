using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float obstacleStep;
    public float startLevel = 5;

    void Start()
    {
        GameManager.Instance.obstacles.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        startLevel = GameManager.Instance.startLevel;
        

        float s = startLevel / (2 / Time.deltaTime);
        transform.Translate(0, -s, 0);

        if (transform.position.y < -5.5)
        {
            GameManager.Instance.obstacles.Remove(this.gameObject);
            this.gameObject.SetActive(false);
        }
            
    }
}
