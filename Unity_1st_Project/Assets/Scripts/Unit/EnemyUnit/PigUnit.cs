public class PigUnit : EnemyUnit
{
    public float _moveSpeed = 0.7f;
    public float _hp = 2000;
    public int _damage = 200;
    public int _unitPrice = 200;
    public float _range = 1;
    protected bool _isAreaAttack = false;

    protected override void OnEnable()
    {
        moveSpeed = _moveSpeed;
        MoveSpeed = moveSpeed;
        hp = _hp;
        damage = _damage;
        unitPrice = _unitPrice;
        attackRange = _range;
        isAreaAttack = _isAreaAttack;
        base.OnEnable();
    }
}
