using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerMovement myPlayer;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    //public TextMeshProUGUI endSceenScore;

    
    public int score;

   

    // Creates a new folder to store data
    const string DIR_DATA = "/Data/";
    // The file the data will be stored in
    const string FINE_HIGH_SCORE = "highScore.text";
    string PATH_HIGH_SCORE;

    //if a new score is higher than old score then score will update
    public int Score
    {
        get{ return score; }
        set
        {
            score = value;
            if ( score > HighScore)
            {
                HighScore = score;
            }
        }
    }

    int highScore;

    //High score is updated and overided if new score is higher than old score
    public int HighScore
    {
        get{ return highScore;}
        set
        {
            highScore = value;
            //This is creating a new folder
            Directory.CreateDirectory(Application.dataPath + DIR_DATA);
            //How to store the data
            File.WriteAllText(PATH_HIGH_SCORE, "" + HighScore);
        }
    }
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        //How Unity finds the data and sets up the data path
        PATH_HIGH_SCORE = Application.dataPath + DIR_DATA + FINE_HIGH_SCORE;
        //myPlayer = FindObjectOfType<PlayerMovement>();
        highScoreText.enabled = false;
        if(File.Exists(PATH_HIGH_SCORE))
        {
            //int32 turns string into int when reading the number from the text file
            HighScore = Int32.Parse(File.ReadAllText(PATH_HIGH_SCORE));
        }

        //endSceenScore.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + Score;
        highScoreText.text = "High Score: " + HighScore;
        
        //if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("EndScene"))
        //{
        //    endSceenScore.text = "High Score: " + HighScore;
            
        //}

       
    }
}
