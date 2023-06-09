using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] float range;

    private EnemyControler enemy;
    private Vector3 targetPoint;
    private int damage;

    public void SetTarget(EnemyControler enemy)
    {
        this.enemy = enemy;
        targetPoint = enemy.transform.position;
        StartCoroutine(CanonRoutine());
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    IEnumerator CanonRoutine()
    {
        float xSpeed = (targetPoint.x - transform.position.x) / time;
        float zSpeed = (targetPoint.z - transform.position.z) / time;
        float ySpeed = -1*(0.5f*Physics.gravity.y*time*time+transform.position.y)/time;

        float curTime = 0;
        while (curTime<time)
        {
            curTime += Time.deltaTime;
            ySpeed += Physics.gravity.y * Time.deltaTime;


            transform.position += new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime;
            yield return null;
        }

        Explosion();
        GameManager.Resource.Destroy(gameObject);
    }

    public void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range, LayerMask.GetMask("Enemy"));
        foreach(Collider collider in colliders)
        {
            EnemyControler enemy = collider.GetComponent<EnemyControler>();
            enemy?.TakeHit(damage);

            //Rigidbody rb = collider.GetComponent<Rigidbody>();
            //rb?.AddExplosionForce()
        }
    }

    public void Attack(EnemyControler enemy)
    {
        Collider[] collider =  Physics.OverlapSphere(transform.position, range);
        enemy.TakeHit(damage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
