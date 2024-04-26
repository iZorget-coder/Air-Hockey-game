using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    public AudioSource[] audioSource;
    public TMP_Text countdownText;
    public GameObject gameUI;
    private PlayerMovement playerMovement;
   

    private int numberIndex;

    private float timer = 3f;

    void Start()
    {
       
        GameObject canStart = GameObject.FindGameObjectWithTag("Player");
        playerMovement = canStart.GetComponent<PlayerMovement>();
        playerMovement.canStart2Play = false;

        countdownText.text = (3).ToString();
       

        InvokeRepeating("Countdown", 1f, 1f);
    }

    private void Update()
    {
        
    }

    void Countdown()
    {

        Levels();

        timer -= 1f;

        if (timer < 0f)
        {
            countdownText.enabled = false;
            gameUI.SetActive(false);
            playerMovement.canStart2Play = true;
           
            CancelInvoke("Countdown");
        }
    }
    public void Levels()
    {
        int count = Mathf.RoundToInt(timer);
        countdownText.text = count.ToString();


        if (count > -1 && count <= audioSource.Length)
        {
            audioSource[count].volume = 1f;
            audioSource[count].Play();
        }

    }
}
