using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{

    void FindEnemy()
    {
        var EnemyCreateInfos = GetComponentsInChildren(typeof(CreateEnemyInfo));

        foreach (CreateEnemyInfo data in EnemyCreateInfos)
        {
            var createdEnemy = data.CreateEnemy();
            if(createdEnemy != null)
            {
                //리스트에 추가..
            }
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


