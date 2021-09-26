using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    public override void EnemySetting(int iFieldUnique, CreateEnemyInfo variableValue)
    {
        this.iFieldUnique = iFieldUnique;
        this.iAttackDamage += variableValue.iCurrectionAttackDamage;
        this.iHealthPoint += variableValue.iCurrectionHealthPoint;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
