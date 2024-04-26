using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portals : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform nextPositionAI, nextPositionPlayer;
    public float distance = 0.2f;
    public bool isPlayerPortal, isAIportal= false;


    void Start()
    {
        nextPositionAI = GameObject.FindGameObjectWithTag("aiPortal").GetComponent<Transform>();
        nextPositionPlayer = GameObject.FindGameObjectWithTag("playerPortal").GetComponent<Transform>();    

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "aiPortal")
        {

            isAIportal = true;
            isPlayerPortal = false;
            if (Vector2.Distance(transform.position, collision.transform.position) < distance && isAIportal)
            {
                isPlayerPortal = false;
                transform.position = new Vector3 (nextPositionPlayer.position.x,nextPositionPlayer.position.y + 1f, nextPositionPlayer.position.z);
               
                
            }
        }
        if (collision.gameObject.tag == "playerPortal")
        {
            isPlayerPortal = true;
            if (Vector2.Distance(transform.position, collision.transform.position) < distance && isPlayerPortal)
            {

                isAIportal = false;
                transform.position = new Vector3(nextPositionAI.position.x, nextPositionAI.position.y - 1f, nextPositionAI.position.z);
               
                
            }
        }
    }
}
