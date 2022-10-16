using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSetting : MonoBehaviour
{
    private int totalTarget;
    public TMP_Text totalText;
    Score gamescore;
    Dice dice;
    Menu gameMenu;

    // Start is called before the first frame update
    void Start()
    {
        dice = GameObject.Find("Dice1").GetComponent<Dice>();
        gameMenu = this.gameObject.GetComponent<Menu>();
        gamescore = this.gameObject.GetComponent<Score>();
        totalTarget = Random.Range(10, 36);
        totalText.text = totalTarget.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Win and lose conditions
        if(gamescore.currentScore > totalTarget)
        {
            gameMenu.DisplayEndText(true);
        }
        else if(dice.diceamount == 0 && gamescore.currentScore < totalTarget)
        {
            gameMenu.DisplayEndText(true);
        }
        if(gamescore.currentScore == totalTarget)
        {
            gameMenu.DisplayEndText(false);
        }
        if (gamescore.currentScore == totalTarget && dice.diceamount >= 0)
        {
            gameMenu.DisplayEndText(false);
        }
    }
}
