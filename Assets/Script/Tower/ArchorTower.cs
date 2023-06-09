using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArchorTower : Tower
{
    [SerializeField] Transform archor;
    [SerializeField] Transform arrowPoint;

    private int damage = 1;
    protected override void Awake()
    {
        base.Awake();

        data = GameManager.Resource.Load<TowerData>("Data/ArchorTowerData");
    }

    private void OnEnable()
    {
        StartCoroutine(LookRoutine());
        StartCoroutine(AttackRoutine());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            if(enemyList.Count > 0)
            {
                Attack(enemyList[0]);
                yield return new WaitForSeconds(data.Towers[0].delay);
            }
            else
            {
                yield return null;
            }
        }
    }
    public void Attack(EnemyControler enemy)
    {
        Arrow arrow = GameManager.Resource.Instantiate<Arrow>("Tower/Arrow",arrowPoint.position,arrowPoint.rotation);
        arrow.SetTarget(enemy);
        arrow.SetDamage(damage);
    }
    IEnumerator LookRoutine()
    {
        while (true)
        {
            if(enemyList.Count > 0)
            {
                archor.LookAt(enemyList[0].transform);
            }

            yield return null;
        }
    }
}
