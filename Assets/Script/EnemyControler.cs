using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyControler : MonoBehaviour
{
    [SerializeField] int hp;
    public int HP { get { return hp; }private set { hp = value; OnChangedHP?.Invoke(hp); } }
    public UnityEvent<int> OnChangedHP;
    public UnityEvent OnDied;

    public void TakeHit(int damage)
    {
        hp-= damage;
        OnChangedHP?.Invoke(hp);

        if (hp <= 0)
        {
            OnDied?.Invoke();
            GameManager.Resource.Destroy(gameObject);
        }
    }
}
