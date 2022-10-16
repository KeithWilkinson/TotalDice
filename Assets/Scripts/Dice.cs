using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public Sprite[] diceSides;
    private SpriteRenderer rend;
    bool hasRolled = false;
    Score  gameScore;
    Menu gameMenu;
    SoundManager soundMan;
    private static int _diceamount;
    private float rollSpeed;
  

    // Use this for initialization
    private void Start()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        _diceamount = 6;
        soundMan = GameObject.Find("GameManager").GetComponent<SoundManager>();
        gameMenu = GameObject.Find("GameManager").GetComponent<Menu>();
        gameScore = GameObject.Find("GameManager").GetComponent<Score>();
        rend = GetComponent<SpriteRenderer>();
        StartCoroutine("RollTheDice");

    }
    // If you left click over the dice then RollTheDice coroutine is started
    private void OnMouseDown()
    {
        if(gameMenu.hasGameStarted)
        {
           hasRolled = true;
           soundMan.PlayPressSound();
            
        }
    }

    private void OnMouseEnter()
    {
        if(gameMenu.hasGameStarted == true)
        {
            rend.material.color = Color.red;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = Color.white;
    }

    public void EnableCollider()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        // Variable to contain random dice side number.
        int randomDiceSide = 0;

        // Final side or value that dice reads in the end of coroutine
        int finalSide = 0;

        // Dice will roll until player presses it
        while(hasRolled == false)
        {
            randomDiceSide = Random.Range(0, 6);

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide];

            yield return new WaitForSeconds(Random.Range(0.2f,0.5f));
        }

        finalSide = randomDiceSide + 1;

        gameScore.UpdateScore(finalSide);
       
        hasRolled = true;
        _diceamount--;
    }

    public int diceamount
    {
        get { return _diceamount; }
        set { _diceamount = value; }
    }
}
