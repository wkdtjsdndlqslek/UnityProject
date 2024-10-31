using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinUnit : PlayerUnit
{
    public float _moveSpeed = 0.7f;
    public float _hp = 2000;
    public int _damage = 200;
    public float _attackSpeed = 3;
    public int _unitPrice = 200;
    public float _range = 1;

    protected override void Awake()
    {
        base.Awake();
        moveSpeed = _moveSpeed;
        hp = _hp;
        damage = _damage;
        attackSpeed = _attackSpeed;
        unitPrice = _unitPrice;
        range = _range;
    }

    private void Start()
    {
        GameManager.Instance.playerList.Add(this);
    }
}
