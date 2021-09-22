using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int IMoney = 0;
    public int ICash = 0;
    public Inventory CInventory = null;
    public Dictionary<int, StageInfo> dicClearStage= new Dictionary<int, StageInfo>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}