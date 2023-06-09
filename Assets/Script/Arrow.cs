using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float speed;

    private EnemyControler enemy;
    private Vector3 targetPoint;
    private int damage;

    public void SetTarget(EnemyControler enemy)
    {
        this.enemy = enemy;
        targetPoint = enemy.transform.position;
        StartCoroutine(ArrowRoutine());
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    IEnumerator ArrowRoutine()
    {
        while (true)
        {
            //Vector3 vector = enemy.transform.position-transform.position;
            //Vector3 dir = vector.normalized;

            //transform.Translate(dir*speed* Time.deltaTime, Space.World);

            if(enemy != null)
            {
                targetPoint=enemy.transform.position;
            }

            transform.LookAt(enemy.transform.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);

            if (Vector3.Distance(targetPoint,transform.position)<0.1f)
            {
                if (enemy != null)
                    Attack(enemy);
                GameManager.Resource.Destroy(gameObject);
                yield break;
            }

            

            /*if(Vector3.Distance(enemy.transform.position, transform.position) < 0.1f)
            {
                // АјАн
                GameManager.Resource.Destroy(gameObject);
                yield break;
            }

            yield return null;*/
        }
    }

    public void Attack(EnemyControler enemy)
    {
        enemy.TakeHit(damage);
    }
}
