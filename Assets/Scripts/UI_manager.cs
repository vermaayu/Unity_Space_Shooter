using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private Image _livesImage;

    [SerializeField]
    private Sprite[] _liveSprites;

    [SerializeField]
    private GameObject _gameOver;
    
    [SerializeField]
    private Text _restart;

    private GameManager _gameManager;

    [SerializeField]
    private Text _highScore;

    

    void Start()
    {
        _gameOver.SetActive(false);
        _scoreText.text = "Score: " + 0;
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        if (_gameManager == null)
        {
            Debug.Log("GameManager is NULL");
        }
    }
    void Update()
    {
        
    }

    public void UpdateScore(int playerscore)
    {
        _scoreText.text = "Score: " + playerscore;
        
    }

    public void UpdateHighScore(int highscr)
    {
        _highScore.text = "High Score: " + highscr; 
    }
    
    public void UpdateLives(int currentLives)
    {
        _livesImage.sprite = _liveSprites[currentLives];
    }

    public void SetGameOver()
    {
        _gameManager.GameOver();
        _gameOver.SetActive(true);
        _restart.gameObject.SetActive(true);
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _gameOver.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _gameOver.SetActive(false);
            yield return new WaitForSeconds(0.5f);

        }
    }

    public void GameFlicker()
    {
        StartCoroutine(GameOverFlickerRoutine());
    }
}
