using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject jumpobstaclePrefab;
    public GameObject snowRabbit;
    public GameObject jumpBar;
    public int rabbitCount;
    private float Timer = 0, jTimer = 0, rabbitTimer = 0, windTimer = 0, randomRabbitBornTime,snowRandomBornTime;

    public List<GameObject> obstacles = new List<GameObject>();
    public float startLevel = 5;
    public static GameManager Instance;

    public bool gameStart = false;

    public ParticleSystem snowWind;
    private void Awake()
    {
        if (!Instance) Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameStart = true;
        randomRabbitBornTime = Random.Range(0, 10);
        snowRandomBornTime = Random.Range(0, 7);
        snowWind.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            randomBorn();
        }
        else
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("QuestionScene");
        }



    }

    void randomBorn()
    {
        Timer += Time.deltaTime;
        jTimer += Time.deltaTime;
        rabbitTimer += Time.deltaTime;
        windTimer += Time.deltaTime;

        if (windTimer > snowRandomBornTime)
        {
            if (snowWind.isPlaying)
                snowWind.Stop();
            else
                snowWind.Play();
            windTimer = 0;
            snowRandomBornTime = Random.Range(3, 7);
        }

        if (rabbitTimer > randomRabbitBornTime)
        {
            rabbitTimer = 0;
            randomRabbitBornTime = Random.Range(0, 10);
            GameObject obj = Instantiate(snowRabbit, transform);
            obj.transform.position = new Vector2(11, Random.Range(-3, 3));
            rabbitCount += 1;
        }
        if (Timer > 5)
        {
            float stoneNumber = startLevel / 5;
            Timer = 0;
            for (int i = 0; i < stoneNumber; i++)
            {
                GameObject obj = Instantiate(obstaclePrefab, transform);
                obj.transform.position = new Vector2(Random.Range(-10, 10), 4.4f);
            }

            startLevel += 0.5f;

        }

        if (jTimer > 10)
        {
            jTimer = 0;
            GameObject obj = Instantiate(jumpobstaclePrefab, transform);
            obj.transform.position = new Vector2(Random.Range(-12.5f, 12.5f), 6f);

        }
    }
}
