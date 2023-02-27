using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float step = 1f;
    // Start is called before the first frame update

    public float jumpDuration = 0;

    public static PlayerMovement Instance;

    private bool onSky = false;
    private void Awake()
    {
        if (!Instance) Instance = this;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameStart)
        {
            Move();
            Jump();
            if (onSky)
                transform.Rotate(new Vector3(0, 0, 1));
            else
                transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (GameManager.Instance.snowWind.isPlaying)
            transform.Translate(0.002f, 0, 0, Space.Self);

        if (transform.position.x < -10)
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);

        if (transform.position.x > 10)
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A)&&!onSky)
        {
            transform.Translate(-step, 0,0,Space.Self);

        }else if (Input.GetKey(KeyCode.D) && !onSky)
        {
            transform.Translate(step, 0, 0, Space.Self);

        }
        else if (Input.GetKey(KeyCode.Space)&&!onSky)
        {
            GameManager.Instance.jumpBar.GetComponent<Slider>().value += Time.deltaTime;
            //Speed up
        }else if (Input.GetKeyUp(KeyCode.Space))
        {
            if (GameManager.Instance.jumpBar.GetComponent<Slider>().value >= 0.5f)
            {
                jumpDuration = GameManager.Instance.jumpBar.GetComponent<Slider>().value;
                onSky = true;
            }
            else
            {
                GameManager.Instance.jumpBar.GetComponent<Slider>().value = 0;
            }
                


        }
    }

    void Jump()
    {
        if (onSky)
            jumpDuration = GameManager.Instance.jumpBar.GetComponent<Slider>().value -= Time.deltaTime/2;
        jumpDuration = Mathf.Clamp(jumpDuration, 0, 3);
        if (GameManager.Instance.jumpBar.GetComponent<Slider>().value == 0)
            onSky = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "obstacle")
        
            GameManager.Instance.gameStart = false;
        

            
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "jumpObstacle")
        {
            if (jumpDuration <= 0)
       
                GameManager.Instance.gameStart = false;
            
                
        }
    }
}
