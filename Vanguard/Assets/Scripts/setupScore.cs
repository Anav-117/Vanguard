using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setupScore : MonoBehaviour
{
    private int Score;
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        if (Score < PlayerPrefs.GetInt("Score")) {
            Score = PlayerPrefs.GetInt("Score");
        }

        txt.text = Score.ToString();
    }
}
