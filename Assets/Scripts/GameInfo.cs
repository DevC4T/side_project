using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{

    void FindEnemy()
    {
        var Enemys = GetComponents(typeof(EnemyFactory));

        foreach (EnemyFactory data in Enemys)
        {
            data.CreateEnemy();
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


