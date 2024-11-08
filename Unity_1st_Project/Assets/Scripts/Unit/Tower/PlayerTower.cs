using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerTower : Unit
{
    public int _hp = 3000;
    public TextMeshProUGUI playerHpText;
    public GameObject defeatPanel;
    public Button defeatLobby;
    public Button defeatRestart;

    protected override void OnEnable()
    {
        hp =_hp;
        base.OnEnable();
        knockBackDistance = 0f;
        knockBackHpRatio = 0f;
    }
    private void Start()
    {
        GameManager.Instance.PlayerTower = this;
    }

    protected override void Update()
    {
        playerHpText.text = $"{hp}/{maxHp}";
        fillImage.fillAmount = HpFillAmount;
    }

    protected override void Die()
    {
        Time.timeScale =0f;
        defeatPanel.SetActive(true);
        defeatLobby.onClick.AddListener(Lobby);
        defeatRestart.onClick.AddListener(Restart);
    }

    private void Lobby()
    {
        GameManager.Instance.Reset();
        SceneManager.LoadScene("StartScene");
    }
    
    private void Restart()
    {
        GameManager.Instance.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale =1f;
    }

    protected override void Move(RaycastHit2D[] hit)
    {
    }
}