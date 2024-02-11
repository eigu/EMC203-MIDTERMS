using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private GameObject player;
    private Player playerEntity;

    [SerializeField] private TextMeshProUGUI playerHealthText;
    [SerializeField] private GameObject gameOverScreen;

    private void Start()
    {
        if (Instance != null && Instance != this) Destroy(this);
        Instance = this;

        player = GameObject.Find("Player");
        playerEntity = player.GetComponent<Player>();

        Time.timeScale = 1;
    }

    private void Update()
    {
        UpdatePlayerHealthUI(playerEntity.currentHealth);
        ShowPlayerDeathUI(playerEntity.currentHealth);
    }

    private void UpdatePlayerHealthUI(int health)
    {
        playerHealthText.text = "Health: " + health;
    }

    private void ShowPlayerDeathUI(int health)
    {
        if (!player)
        {
            Time.timeScale = 0;
            playerHealthText.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }
}
