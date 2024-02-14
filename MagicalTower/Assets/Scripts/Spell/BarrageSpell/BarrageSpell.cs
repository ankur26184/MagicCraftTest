using AVFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageSpell : BaseSpell
{
    [SerializeField] private float m_DamageToTarget;
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.collider.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().OnDamage(m_DamageToTarget);
        }       
    }
}
