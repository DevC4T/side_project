using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFactory : MonoBehaviour
{
    public abstract Enemy CreateEnemy();
}

public class TestEnemyCreator : EnemyFactory
{
    public override Enemy CreateEnemy()
    {
        return new TestEnemy();
    }
}

//적 추가시 해당으로 추가하면됨
//public class TestEnemyCreator : EnemyFactory
//{
//    public override Enemy CreateEnemy()
//    {
//        return new TestEnemy();
//    }
//}