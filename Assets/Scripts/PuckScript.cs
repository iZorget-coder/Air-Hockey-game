using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PuckScript : MonoBehaviour
{
    private Rigidbody2D rigidB;
    private Rigidbody2D rgPlayer;
    private Rigidbody2D rgOpp;
    public GameObject half;
    private PlayerMovement player_;
    public int aiTouchesBalance, playerTouchBalance;
    private float playerX, playerY;
    private  float opponentX, opponentY;
    public Score scores;
    public int playerTouches, AItouches;

    // Start is called before the first frame update
    void Start()
    {
        playerTouches = AItouches = 0;
        GameObject scoreHolder = GameObject.FindGameObjectWithTag("ScoreHolder");
        GameObject opponent = GameObject.FindGameObjectWithTag("Opponent");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player_ = player.GetComponent<PlayerMovement>();
        scores = scoreHolder.GetComponent<Score>();
        rigidB = GetComponent<Rigidbody2D>();
       
        rgPlayer = player.GetComponent<Rigidbody2D>();
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        opponentX = opponent.transform.position.x;
        opponentY = opponent.transform.position.y;
        rgOpp = opponent.GetComponent<Rigidbody2D>();


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "AIgoal")
        {

            scores.playerPoints++;
           new WaitForSecondsRealtime(1);
            player_.isGoal = true;
         
            rgPlayer.position = new Vector3(playerX, playerY,0);

            rgOpp.position = new Vector3(opponentX, opponentY, 0);
            rigidB.velocity = rigidB.position = new Vector2(0, 0);
        
        }else if(collision.gameObject.tag == "PlayerGoal")
        {
            player_.isGoal = true;
            scores.aiPoints++;
           
            new WaitForSecondsRealtime(1);
            rigidB.velocity = rigidB.position = new Vector2(0, 0);

            rgPlayer.position = new Vector3(playerX, playerY, 0);

            rgOpp.position = new Vector3(opponentX, opponentY, 0);
        }
        if (collision.gameObject.tag == "Opponent")
        { AItouches++; if (AItouches == aiTouchesBalance) { scores.aiPoints -= 1; AItouches = 0; } }
        if (collision.gameObject.tag == "Player")
        { playerTouches++;
            if (playerTouches == playerTouchBalance) { scores.playerPoints -=1; playerTouches = 0; }
        }
        }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < half.transform.position.y)
        {
            AItouches = 0;
        } else if(transform.position.y > half.transform.position.y)
        {
            playerTouches = 0;

        }
        {

        }
        if (!player_.canStart2Play)
        {
            rigidB.constraints = RigidbodyConstraints2D.FreezeAll;
        }else if (player_.canStart2Play)
        {
            rigidB.constraints = RigidbodyConstraints2D.None;
        }
    }
}
