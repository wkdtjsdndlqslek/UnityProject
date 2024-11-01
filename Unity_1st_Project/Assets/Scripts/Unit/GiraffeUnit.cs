using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiraffeUnit : PlayerUnit
{
    public float _moveSpeed = 0.5f;
    public float _hp = 6000;
    public int _damage = 2000;
    public float _attackSpeed = 3;
    public int _unitPrice = 2700;
    public float _range = 5;
    public Image fillImage;
    private float HpFillAmount { get { return hp/maxHp; } }

    protected override void Awake()
    {
        base.Awake();
        hp = _hp;
        moveSpeed = _moveSpeed;
        damage = _damage;
        attackSpeed = _attackSpeed;
        unitPrice = _unitPrice;
        range = _range;
    }

    protected override void Update()
    {
        base.Update();
        fillImage.fillAmount = HpFillAmount;
    }

    private void Start()
    {
        GameManager.Instance.playerList.Add(this);
    }
}
