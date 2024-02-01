using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour //To Do For Final Submission: Score, Game Over, Level Change. -AC//
{
    public Ghost[] ghosts;

    public Player player;

    public Transform pellete;

    [SerializeField] TextMeshProUGUI highscoreText;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI PlayerReadytext;

    public TextMeshProUGUI Playerlosttext;

    int scoreCount;

    public GameObject firstlife; //Life capsules

    public GameObject lastlife;

    public GameObject middlelife;

    public int score { get; private set; }
    public int lives { get; private set; }

    public int ghostMultiplier { get; private set; } = 1; //Flesh out if we decide to add score multiplier. -AC//

    private void Start()
    {
        UpdateHighscoreText();
        Playerlosttext.enabled = false;
        NewGame();
        StartCoroutine(startcountdown()); //Small countdown at start of game
        firstlife.gameObject.SetActive(true);
        middlelife.gameObject.SetActive(true);
        lastlife.gameObject.SetActive(true);
        score = 0;
    }
    IEnumerator startcountdown() //Short countdown at start of game
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1f;
        PlayerReadytext.enabled = false;
    }
  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) //Restart button
        {
            RestartGame();
        }

        if (Input.GetKeyDown("escape")) //Quit out game button
        {
            Debug.Log("Player has quit");
            Application.Quit();
        }
    }

    public void RestartGame()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
    }

    private void NewRound()
    {
        foreach (Transform pellete in this.pellete) {
            pellete.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void LevelTwo() //This line may prove redundant. Too bad! It's here for now. -AC//
    {

    }

    private void ResetState(){

        for (int i = 0; i < this.ghosts.Length; i++) {
            this.ghosts[i].gameObject.SetActive(true);
        }

        this.player.ResetState();
    }


    private void GameOver()
    {
        Playerlosttext.enabled = true; //gameover text
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreCount = score;
        Debug.Log("highscorecount" + scoreCount);
        Debug.Log("normalscorecount" + this.score);
        CheckHighScore();
        UpdateHighscoreText();
    }

    void CheckHighScore()
    {
        if (scoreCount > PlayerPrefs.GetInt("HighScore", 0))
        {
            Debug.Log("Highscore Updated");
            PlayerPrefs.SetInt("HighScore", scoreCount);
        }
    }

    private void UpdateHighscoreText()
    {
        Debug.Log("" + highscoreText.text);
        highscoreText.text = $"{PlayerPrefs.GetInt("HighScore", 0)}";
    }


    private void SetLives(int lives)
    {
        this.lives = lives;
    }
    

    public void GhostEaten(Ghost ghost)
    {
        SetScore(this.score + ghost.points);
    }

    public void PlayerDefeated() //Call game over from here perhaps? -AC//
    {
        this.player.gameObject.SetActive(false);

        SetLives(this.lives - 1);

        if (this.lives > 0) {
            Invoke(nameof(ResetState), 2.0f);
        } else {
            lastlife.gameObject.SetActive(false);
            GameOver();
        }

        if (this.lives < 3)
        {
            firstlife.gameObject.SetActive(false);
        }
        else if (this.lives < 2)
        {
            middlelife.gameObject.SetActive(false);
        }
    }

    public void PelletEaten(Pellete pellete)
    {
       
        pellete.gameObject.SetActive(false);
        SetScore(this.score + pellete.points);

        scoreText.text = ""+this.score;
    }

    public void PowerPelletEaten (PowerPellet pellete)
    {
        PelletEaten(pellete);

        StartCoroutine(powercountdown());
    }

    IEnumerator powercountdown() //Power Up Countdown
    {
        Debug.Log("POWER UP!");
        GameObject.Find("Ghosts").GetComponent<GhostFrightened>(); //Would this even work? We will have to find out
        yield return new WaitForSecondsRealtime(8);

        Debug.Log("POWER UP GONE!");



    }
}


