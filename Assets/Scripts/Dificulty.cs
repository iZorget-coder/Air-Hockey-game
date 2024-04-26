using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dificulty : MonoBehaviour
{
    // Start is called before the first frame update
    private AI_Script mode;
    private PuckScript aiAffordance;
    public TMP_Text difficulty;

 
 
    public enum Difficulty
    {
       superEasy,
       mid,
       hard,
       godMode
    }
    public Difficulty difficultyMode;   
    void Start()
    {
        GameObject aiTouch = GameObject.FindGameObjectWithTag("Puck");
        aiAffordance = aiTouch.GetComponent<PuckScript>();
        GameObject gameMode = GameObject.FindGameObjectWithTag("Opponent");
        mode = gameMode.GetComponent<AI_Script>();
        difficultyMode = Difficulty.superEasy;
        mode.maxSpeed = 5;
        mode.moveVelocity = 2;
        aiAffordance.aiTouchesBalance = 6;
        aiAffordance.playerTouchBalance = 2;
    }

    // Update is called once per frame

    public void DropDown(int index)
    {
        switch(index)
        {
            case 0:
               difficultyMode = Difficulty.superEasy;
                mode.moveVelocity = 2f;
                mode.maxSpeed = 5f;
                aiAffordance.aiTouchesBalance = 7;
                aiAffordance.playerTouchBalance = 2;
                difficulty.text = "super easy";
                break;
                case 1:
                aiAffordance.playerTouchBalance = 4;
                difficultyMode = Difficulty.mid;
                mode.moveVelocity = 20;
                mode.maxSpeed = 2f;
                aiAffordance.aiTouchesBalance = 5;
                difficulty.text = "mid";
                break;
            case 2:
                aiAffordance.playerTouchBalance = 3;
                difficultyMode = Difficulty.hard;
                mode.moveVelocity = 30;
                mode.maxSpeed = 4f;
                aiAffordance.aiTouchesBalance = 3;
                difficulty.text = "hard";
                break;
                case 3:
                aiAffordance.playerTouchBalance = 4;
                difficultyMode = Difficulty.godMode;
                mode.moveVelocity = 40;
                mode.maxSpeed = 5f;
                aiAffordance.aiTouchesBalance = 7;
                difficulty.text = "god mode";
                break;
        }
    }
    void Update()
    {
      
        
    }
}
