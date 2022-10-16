using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    private static bool _hasGameStarted = false;
    public TMP_Text startText;
    public TMP_Text winText;
    public TMP_Text loseText;
    public Dice[] dice;
    
    // Start is called before the first frame update
    void Start()
    {
        loseText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        startText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Starts game when any key is pressed
        if (Input.anyKeyDown && !(Input.GetMouseButtonDown(0) || (Input.GetMouseButtonDown(1) || (Input.GetMouseButtonDown(2)))))
        {
            foreach(Dice d in dice)
            {
                d.EnableCollider();
            }
            _hasGameStarted = true;
            startText.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    // Restart game 
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 0;
      
    }

    // Displays end game text based on if player won or lost
    public void DisplayEndText(bool hasLost)
    {
        if(hasLost == true)
        {
            loseText.gameObject.SetActive(true);
            Time.timeScale = 0;
            if(Input.GetKeyDown(KeyCode.R))
            {
                loseText.gameObject.SetActive(false);
                RestartGame();
            }
        }
        else
        {
            winText.gameObject.SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.R))
            {
                winText.gameObject.SetActive(false);
                RestartGame();
            }
        }
    }

    public bool hasGameStarted
    {
        get { return _hasGameStarted; }
        set { _hasGameStarted = value; }
    }
}
