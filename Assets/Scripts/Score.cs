using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int _currentScore = 0;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = _currentScore.ToString();
    }

    // Updates score
    public void UpdateScore(int scoretoadd)
    {
        _currentScore += scoretoadd;
    }

    public int currentScore
    {
        get {return _currentScore;}
        set { _currentScore = value; }
    }
} 

