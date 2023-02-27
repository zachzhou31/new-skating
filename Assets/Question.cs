using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    public GameObject buttons;
    public GameObject answer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < buttons.transform.childCount; i++)
        {
            buttons.transform.GetChild(i).GetComponentInChildren<Text>().text = (GameObject.Find("GameData").GetComponent<GameData>().rabbitCount+i).ToString();
        }


    }

    public void Right()
    {
        answer.GetComponent<Text>().text = "Right";
    }

    public void Wrong()
    {
        answer.GetComponent<Text>().text = "Wrong";
    }
}
