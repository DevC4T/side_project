using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager instance = null;
    public static EnemyManager Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject enemyManagerObject = new GameObject("EnemyManger");
                DontDestroyOnLoad(enemyManagerObject);
                instance = new EnemyManager();
            }
            return instance;
        }
    }

    private int iIssuanceFieldUnique = 1; //발행유니크
    private Dictionary<int, EnemyFactory> EnemyDictionary = new Dictionary<int, EnemyFactory>();
    //문서데이터가없으니 일단은 int로 해둠
    private Dictionary<int, int> EnemyCsvDataDictionary = new Dictionary<int, int>();

    private Dictionary<int, GameObject> enemyObjectDictionary = new Dictionary<int, GameObject>();
    // Start is called before the first frame update
    void awake()
    {
        EnemyDictionary.Add((int)Define.EnemyNumber.ENEMY_TEST,new TestEnemyCreator()); //미리 생성오브젝트를 생성해둠
    }

    public Enemy CreateEnemy(CreateEnemyInfo enemyInfo)
    {
        
        if(EnemyDictionary[enemyInfo.eEnemyNumber] == null)
        {
            Debug.LogError("Enemy number is not defined or not registed enemyManager..");
            return null;
        }
        Enemy createEnemy = EnemyDictionary[enemyInfo.eEnemyNumber].CreateEnemy();
        createEnemy.EnemySetting(iIssuanceFieldUnique,  enemyInfo); //여기서 추가 변형값? 변경하고.. + 문서데이터 추가
        //GameObject enemyobject = GameObject.Instantiate(createEnemy);
        
        //enemyObjectDictionary.Add(iIssuanceFieldUnique++, )
        return createEnemy;
    }


}
