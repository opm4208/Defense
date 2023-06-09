using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackRange : MonoBehaviour
{
    public Tower tower;
    public LayerMask enemyMask;

    public UnityEvent<EnemyControler> OnInRangeEnemy;
    public UnityEvent<EnemyControler> OnOutRangeEnemy;


    private void OnTriggerEnter(Collider other)
    {
        if(enemyMask.IsContain(other.gameObject.layer))
        {
            EnemyControler enemy = other.GetComponent<EnemyControler>();
            OnInRangeEnemy?.Invoke(enemy);

            enemy.OnDied.AddListener(() => { OnOutRangeEnemy?.Invoke(enemy); });
            //tower.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (enemyMask.IsContain(other.gameObject.layer))
        {
            EnemyControler enemy = other.GetComponent<EnemyControler>();
            //tower.RemoveEnemy(enemy);
            OnOutRangeEnemy?.Invoke(enemy);
        }
    }
}
