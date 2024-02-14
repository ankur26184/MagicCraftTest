using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AVFramework;

public abstract  class BaseSpell : PoolObject
{
    [SerializeField] private float m_LaunchAngle = 45f;
    [SerializeField] private float m_LaunchSpeed = 10f;
    [SerializeField] private Rigidbody m_Rigidbody;

    public void Fire(Vector3 targetPosition)
    {
        try
        {
            Vector3 dir = targetPosition - transform.position; // get target direction
            float h = dir.y;  // get height difference
            dir.y = 0;  // retain only the horizontal direction
            float dist = dir.magnitude;  // get horizontal distance
            dir.y = dist;  // set elevation to 45 degrees
            dist += h;  // correct for different heights
            float vel = Mathf.Sqrt(Mathf.Abs(dist) * Physics.gravity.magnitude);
            m_Rigidbody.velocity = vel * dir.normalized;
        }
        catch
        {
            m_Rigidbody.velocity = new Vector3(1, 1, 1) * 10;
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        AddObjectToPool();
    }

    public override void SetActive(bool active)
    {
        base.SetActive(active);

        gameObject.SetActive(active);
    }
}
