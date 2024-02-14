using AVFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpellSpawnManager : BaseSpellSpawnManager
{
    public override void ShootSpell()
    {
       FireballSpell fireballSpell = GetSpell<FireballSpell>();
       fireballSpell.transform.position = transform.position;
       List<PoolObject> enemyList = EnemyGenerationManager.Instance.GetActiveEnemyList();

       int rand = Random.Range(0, enemyList.Count);
       fireballSpell.Fire(enemyList[rand].transform.position);
    }
}
