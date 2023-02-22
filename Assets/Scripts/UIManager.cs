using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TMP_Text score;
    public TMP_Text startScreen;
    
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        score.text = "Score: " + GameManager.instance.currentScore;
        startScreen.text = "Press any key to continue";
    }
}
