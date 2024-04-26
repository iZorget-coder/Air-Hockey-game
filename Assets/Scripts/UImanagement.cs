using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UImanagement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject paused;
   public Levels winOrLoseSounds;
    private PuckScript scoreOutcome;
    
    public Score outcome;
    private PlayerMovement player_;
    public GameObject settings;

    void Start()
    {
      
       
        settings.SetActive(false);
       
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player_ = player.GetComponent<PlayerMovement>();
        GameObject puckScriptHolder = GameObject.FindGameObjectWithTag("Puck");
        scoreOutcome = puckScriptHolder.GetComponent<PuckScript>();
        GameObject winORlose = GameObject.FindGameObjectWithTag("ScoreHolder");
        winOrLoseSounds = winORlose.GetComponent<Levels>();
        outcome = winORlose.GetComponent<Score>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)) { Time.timeScale = 0f; player_.canStart2Play = false; paused.SetActive(true); }
      
       
    }  
    public void Resume() { paused.SetActive(false); Time.timeScale = 1f; player_.canStart2Play = true; }
    
    public void PlayAgain()
    {
        /*Time.timeScale = 1;
        outcomesUI.SetActive(false);
        scoreOutcome.scores.aiPoints = scoreOutcome.scores.playerPoints = scoreOutcome.scores.startingScore;
        scoreOutcome.scores.gameOver = false;  Attempting to restart the game when all i could've used is one simple line of code 
        */
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void OpenSettings()
    {
        settings.SetActive(true);
        player_.canStart2Play = false;
        Time.timeScale = 0f;
        paused.SetActive(false);
    }
    public void CloseSettings()
    {
        settings.SetActive(false);
        player_.canStart2Play = false;
        Time.timeScale = 0f;
        paused.SetActive(true);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
