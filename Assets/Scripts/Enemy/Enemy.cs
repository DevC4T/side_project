using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int iFieldUnique;
    public int iEnemyNumber;
    public int iHealthPoint;
    public int iAttackDamage;
    public abstract void EnemySetting(int iFieldUnique, CreateEnemyInfo variableValue);

}
