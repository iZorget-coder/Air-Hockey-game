using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class Score : MonoBehaviour
{
    public Levels sounds;
    // Start is called before the first frame update
    public TMP_Text PlayerPointsTXT, AIPointsTXT;
    public int aiPoints, playerPoints;
    public int maxPoints = 2;
    public string winner;
    public bool gameOver;
    public GameObject AIscore, playerScore;
    public AudioSource outcomeWin; 
    public AudioSource outcomeLose;
    public GameObject outcomesUI;
    public float volumeLevels = 1;
    public int startingScore = 0;
    public AudioClip win;
    public AudioClip lose;

    public TMP_Text endResult;

    void Start()
    {
        outcomeWin.volume = volumeLevels;
        outcomeLose.volume = volumeLevels;
        outcomeWin.clip = win;
        outcomeLose.clip = lose;

        
        outcomesUI.SetActive(false);
        GameObject player = GameObject.FindGameObjectWithTag("ScoreHolder");
      sounds = player.GetComponent<Levels>();
        gameOver = false;


        aiPoints = startingScore;
        playerPoints = startingScore;
       



    }

    // Update is called once per frame
    void Update()
    {
        AIPointsTXT.text = (aiPoints).ToString();
        PlayerPointsTXT.text = (playerPoints).ToString();

        if ((playerPoints == maxPoints) || (aiPoints == maxPoints))
        {
            gameOver = true;


        }

            if ((playerPoints == maxPoints && playerPoints > aiPoints && gameOver))
            {
            
            PlayerPointsTXT.text = ($"Win");
            playerPoints++;
            outcomesUI.SetActive(true);
            outcomeWin.Play();
            endResult.text = ($"Won! by {(playerPoints-1) - aiPoints} points");
            winner = ("Player");
            AIscore.SetActive(false);
            playerScore.SetActive(false);

           


             }
        else if ((aiPoints== maxPoints && playerPoints < aiPoints && gameOver))
        {
            aiPoints++;
            
            outcomesUI.SetActive(true);
          outcomeLose.Play();
            endResult.text = ($"Lost! by {(aiPoints-1) - playerPoints} points");
                winner = "AI";
            AIscore.SetActive(false);
            playerScore.SetActive(false);


        }
            if(playerPoints < 0)
        {
               playerPoints = 0;

        }
            if(aiPoints < 0)
        {
            aiPoints = 0;
        }
       
            
     }
        
     
    public void ResetPoints()
    {
        aiPoints = 0;
        playerPoints = 0;
        AIPointsTXT.text = "0";
        PlayerPointsTXT.text = "0";
    }
}
