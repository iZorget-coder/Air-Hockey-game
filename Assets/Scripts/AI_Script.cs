using UnityEngine;


public class AI_Script : MonoBehaviour
{
    
    
    public float maxSpeed;
    public float moveVelocity; 
    private Rigidbody2D rigidB;
    private Vector2 initialPosition;
    public Rigidbody2D HockeyPuck;
    public Transform PlayerBoundaryHolder;
    private Bounds playerBoundary;
    private Bounds puckBoundary;
    public Vector2 targetPosition;
    private bool firstTimeInRange = true;
    public float offset;
    public Transform targetObject;
    public float distanceToStartThrowing = 2f;
    private PlayerMovement player_;

    void Start()
    {

        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player_ = player.GetComponent<PlayerMovement>();
        rigidB = GetComponent<Rigidbody2D>();
        initialPosition = rigidB.position;
        playerBoundary = new Bounds(PlayerBoundaryHolder.GetChild(0).position.x,
                              PlayerBoundaryHolder.GetChild(1).position.y,
                              PlayerBoundaryHolder.GetChild(2).position.x,
                              PlayerBoundaryHolder.GetChild(3).position.y);
        
        puckBoundary = new Bounds(PlayerBoundaryHolder.GetChild(0).position.y,
                              PlayerBoundaryHolder.GetChild(1).position.y,
                              PlayerBoundaryHolder.GetChild(2).position.x,
                              PlayerBoundaryHolder.GetChild(3).position.x);
    }

    void Update()
    {

    
        if (!player_.canStart2Play)
        {
            rigidB.constraints = RigidbodyConstraints2D.FreezeAll;
        }else if (player_.canStart2Play)
        {
            rigidB.constraints = RigidbodyConstraints2D.None;
        }
        float movementspeed;
       

       
        
        if (HockeyPuck.position.y < puckBoundary.Down)
        {
            if (firstTimeInRange)
            {
               firstTimeInRange = false;
                offset = Random.Range(-0.1f , 4f); 

            }
           
         
            targetPosition = new Vector2(Mathf.Clamp(HockeyPuck.position.x,
                playerBoundary.Right, playerBoundary.Left), initialPosition.y);
        }
        else
        {
            firstTimeInRange = true;

            movementspeed = Random.Range(maxSpeed * moveVelocity, maxSpeed);
          
            targetPosition = new Vector2(HockeyPuck.position.x, HockeyPuck.position.y);
        }
        if (Vector2.Distance(transform.position, targetObject.position) < distanceToStartThrowing )
        {
           
            movementspeed = (maxSpeed * moveVelocity)*5;
            offset = Random.Range(-0.1f, 2f);
            rigidB.MovePosition(Vector2.MoveTowards(rigidB.position, targetPosition, movementspeed * Time.deltaTime));

        }
        else 
        {
            movementspeed = maxSpeed * Random.Range(moveVelocity, moveVelocity);
            rigidB.MovePosition(Vector2.MoveTowards(rigidB.position, targetPosition, movementspeed * Time.deltaTime));


        }


    }

    public void ResetPosition()
    {
        rigidB.position = initialPosition;
    }
}
