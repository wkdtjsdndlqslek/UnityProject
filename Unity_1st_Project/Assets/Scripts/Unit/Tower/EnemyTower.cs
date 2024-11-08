using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyTower : Unit
{
   
    public int _hp =9000;
    public TextMeshProUGUI hpText;
    public GameObject clearPanel;
    public Button clearLobby;

    protected override void OnEnable()
    {
        hp=_hp;
        base.OnEnable();
        knockBackDistance = 0f;
        knockBackHpRatio = 0f;
    }

    private void Start()
    {
        GameManager.Instance.EnemyTower=this;
    }
    
    protected override void Update()
    {
        fillImage.fillAmount = HpFillAmount;
        hpText.text = $"{hp}/{maxHp}";
    }

    protected override void Die()
    {
        Time.timeScale = 0f;
        clearPanel.SetActive(true);
        clearLobby.onClick.AddListener(Lobby);
    }

    private void Lobby()
    {
        GameManager.Instance.Reset();
        SceneManager.LoadScene("StartScene");
    }

    protected override void Move(RaycastHit2D[] hit)
    {
    }
}

