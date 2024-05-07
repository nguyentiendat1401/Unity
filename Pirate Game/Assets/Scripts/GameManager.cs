using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private GameObject inGamePanel;
    [SerializeField]
    private GameObject endGamePanel;
    [SerializeField]
    private Rigidbody2D shipBody;

    public bool isStart;
    private float shipFallSpeed;

    private int coin;
    [SerializeField]
    private TMP_Text coinText;

    private void Start()
    {
        if (Instance == null)
            Instance = this;

        coin = PlayerPrefs.GetInt(Constants.COIN);
        coinText.text = coin.ToString();
    }
    private void Update()
    {
        if (isStart)
        {
            shipFallSpeed = Mathf.MoveTowards(Constants.SHIP_MIN_SPEED, Constants.SHIP_MAX_SPEED, 0.1f * Time.deltaTime);
        }
        shipBody.velocity = new Vector2(0, -shipFallSpeed);
    }

    public void PlayButton()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
        inGamePanel.SetActive(true);
        shipBody.gravityScale = 1;
        isStart = true;
    }

    public void EndGame()
    {
        PlayerPrefs.SetInt(Constants.COIN, coin);
        inGamePanel.SetActive(false);
        endGamePanel.SetActive(true);
        isStart = false;
        Time.timeScale = 0;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UpdateCoin()
    {
        coin++;
        coinText.text = coin.ToString();
        Debug.Log(coin);
    }


}
