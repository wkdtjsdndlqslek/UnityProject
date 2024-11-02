using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiraffeUnit : PlayerUnit
{
    public float _moveSpeed = 0.5f;
    public float _hp = 6000;
    public int _damage = 2000;
    public int _unitPrice = 2700;
    public float _range = 5;
    protected bool _isAreaAttack = true;

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
