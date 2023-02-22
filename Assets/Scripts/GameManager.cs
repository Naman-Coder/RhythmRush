using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource music;
    public bool startPlaying;
    public static GameManager instance;
    public float currentScore;
    public AudioSource click;
    public bool gameStarted = false;
    public GameObject bs;
    public TMP_Text startScreen;
    
    
    void Start()
    {
        instance = this;
        currentScore = 0;
        bs.SetActive(false);
    }
    

    void Update()
    {
        // Check if the game has started
        if (!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                gameStarted = true;
                bs.SetActive(true);
                startScreen.gameObject.SetActive(false);
            }
        }
            
            return;
        }
    }

