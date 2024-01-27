using UnityEngine;

public class GameManager : MonoBehaviour //To Do For Final Submission: Score, Game Over, Level Change. -AC//
{
    public Ghost[] ghost;

    public player player;

    public Transform pellete; 

    public int score { get; private set; }
    public int lives { get; private set; }

    public int ghostMultiplier { get; private set; } = 1; //Flesh out if we decide to add score multiplier. -AC//

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(2);
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

        for (int i = 0; i < this.ghost.Length; i++) {
            this.ghost[i].gameObject.SetActive(true);
        }

        this.player.ResetState();
    }


    private void GameOver()
    {

    }

    private void SetScore(int score)
    {
        this.score = score;
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
            GameOver();
        }
    }

    public void PelletEaten(Pellete pellete)
    {
        pellete.gameObject.SetActive(false);
        SetScore(this.score + pellete.points);
    }

    public void PowerPelletEaten (PowerPellet pellete)
    {
        PelletEaten(pellete);


    }

}
