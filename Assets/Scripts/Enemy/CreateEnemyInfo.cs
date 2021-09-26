using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemyInfo : MonoBehaviour
{
    [Range((int)0, (int)Define.EnemyNumber.ENEMY_MAX)]
    public int eEnemyNumber;
    [Range(0, 10000)]
    public int iCurrectionHealthPoint;
    [Range(0, 10000)]
    public int iCurrectionAttackDamage;

    public Enemy CreateEnemy()
    {
        return EnemyManager.Instance.CreateEnemy(this);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.transform.position, 10.0f);
    }

}

