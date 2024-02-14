using AVFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : BaseSpell
{
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.collider.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.OnDead();
        }
    }
}
