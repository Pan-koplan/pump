using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _playerScore;
    private int _computerScore;
    private int scoreToReach = 3;
    public Ball ball;
    public Paddle playerPaddle;
    public Paddle computerPaddle;
    public Text playerScoreText;
    public Text computerScoreText;

    public void PlayerScore()
    {
        _playerScore++;

        this.playerScoreText.text = _playerScore.ToString();
        CheckScore();
        ResetRound();
    }

    public void ComputerScore()
    {
        _computerScore++;

        this.computerScoreText.text = _computerScore.ToString();
        CheckScore();
        ResetRound();
    }

    private void ResetRound()
    {
        this.playerPaddle.ResetPosition();
        this.computerPaddle.ResetPosition();
        this.ball.ResetPosition();
        this.ball.AddStartingForce();
    }

    private void CheckScore()
    {
        if (_computerScore == scoreToReach)
        {
            SceneManager.LoadScene(2);
        }

        /*if (_playerScore == scoreToReach) //Если очки игрока равны 3, то есть игрок выигрывает, загружается main сцена
                                          // Main сцену тебе нужно вписать в ()
        {
            SceneManage.LoadScene()
        }*/
    }

}

