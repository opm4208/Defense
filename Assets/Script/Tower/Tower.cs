using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    protected TowerData data;
    protected List<EnemyControler> enemyList;

    protected virtual void Awake()
    {
        enemyList = new List<EnemyControler>();
    }

    public void AddEnemy(EnemyControler enemy)
    {
        enemyList.Add(enemy);
    }

    public void RemoveEnemy(EnemyControler enemy)
    {
        enemyList.Remove(enemy);
    }
}
