using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyUnit : PlayerUnit
{
    public float _moveSpeed = 1f;
    public float _hp = 1000;
    public int _damage = 200;
    public int _unitPrice = 50;
    public float _range = 1;
    protected bool _isAreaAttack = false;

    protected override void Awake()
    {
        moveSpeed = _moveSpeed;
        hp = _hp;
        damage = _damage;
        unitPrice = _unitPrice;
        attackRange = _range;
        isAreaAttack = _isAreaAttack;
        base.Awake();
    }

    private void Start()
    {
        GameManager.Instance.playerList.Add(this);
    }
}
