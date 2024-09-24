using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private Paddle playerPaddle;
    [SerializeField] private Paddle computerPaddle;
    [SerializeField] private Text playerScoreText;
    [SerializeField] private Text computerScoreText;

    private int playerScore;
    private int computerScore;

    public GameObject overUI;
    public GameObject winUI;

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            NewGame();
        }
    }

    public void NewGame()
    {
        SetPlayerScore(0);
        SetComputerScore(0);
        NewRound();
    }

    public void NewRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();

        CancelInvoke();
        Invoke(nameof(StartRound), 1f);
    }

    private void StartRound()
    {
        ball.AddStartingForce();
    }

    public void OnPlayerScored()
    {
        SetPlayerScore(playerScore + 1);
        if (playerScore >= 5)
        {
            Time.timeScale = 0f;
            winUI.SetActive(true);
        }
        else
        {
            NewRound();
        }
    }

    public void OnComputerScored()
    {
        SetComputerScore(computerScore + 1);
        if (computerScore >= 5)
        {
            Time.timeScale = 0f;
            overUI.SetActive(true);
        }
        else
        {
            NewRound();
        }
    }

    private void SetPlayerScore(int score)
    {
        playerScore = score;
        playerScoreText.text = score.ToString();
    }

    private void SetComputerScore(int score)
    {
        computerScore = score;
        computerScoreText.text = score.ToString();
    }
}
