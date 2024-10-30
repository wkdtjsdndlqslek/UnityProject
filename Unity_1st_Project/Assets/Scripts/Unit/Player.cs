using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    protected virtual void Awake()
    {
        camp = "Player";
        enemyCamp = "Enemy";
        gameObject.tag = camp;
    }
}
