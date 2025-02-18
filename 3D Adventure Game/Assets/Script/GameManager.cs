using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerMovement myPlayer;

    public int score;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance = null)
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
        myPlayer = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        score = myPlayer.score;
    }
}
