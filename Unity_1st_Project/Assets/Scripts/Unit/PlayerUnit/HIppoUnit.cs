using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HippoUnit : PlayerUnit
{
    public float _moveSpeed = 0.5f;
    public float _hp = 8000;
    public int _damage = 1500;
    public float _attackSpeed = 3;
    public int _unitPrice = 1500;
    public float _range = 1;

    protected override void Awake()
    {
        moveSpeed = _moveSpeed;
        hp = _hp;
        damage = _damage;
        unitPrice = _unitPrice;
        range = _range;
        base.Awake();
    }

    private void Start()
    {
        GameManager.Instance.playerList.Add(this);
    }
}
