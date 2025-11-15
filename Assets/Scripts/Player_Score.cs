using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
public class Player_Score : MonoBehaviour
{
    public float timeLeft = 120;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
    public GameObject WIN;

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("TIME" + "\n" + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("BACKWARD HAT GUY" + "\n" + playerScore);
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CountScore();
        WIN.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Touched the end of the level");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check by Tag
        if (collision.gameObject.CompareTag("Jump"))
        {
            playerScore = playerScore + 200;
        }
        else if(collision.gameObject.CompareTag("Super"))
        {
            playerScore = playerScore + 1000;
        }
    }

        
        void CountScore()
    {
        playerScore = playerScore + (int)(timeLeft * 10);
    }
}
