using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrotUnit : PlayerUnit
{
    public float _moveSpeed = 1.2f;
    public float _hp = 800;
    public int _damage = 900;
    public float _attackSpeed = 3;
    public int _unitPrice = 350;
    public float _range = 3;

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
