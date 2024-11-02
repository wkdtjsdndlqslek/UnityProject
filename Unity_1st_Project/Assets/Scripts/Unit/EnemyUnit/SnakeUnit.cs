using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeUnit : EnemyUnit
{
    public float _moveSpeed = 1.2f;
    public float _hp = 800;
    public int _damage = 900;
    public int _unitPrice = 350;
    public float _range = 3;

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
        GameManager.Instance.enemyList.Add(this);
    }
}
