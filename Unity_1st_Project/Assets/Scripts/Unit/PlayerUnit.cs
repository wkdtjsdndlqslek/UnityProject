using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    protected override void Awake()
    {
        base.Awake();
        camp = "Player";
        enemyCamp = "Enemy";
        gameObject.tag = camp;
    }
}
