using AVFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageSpellSpawnManager : BaseSpellSpawnManager
{
    public override void ShootSpell()
    {
        List<PoolObject> enemyList = EnemyGenerationManager.Instance.GetActiveEnemyList();

        for(int i = 0; i < enemyList.Count; i++)
        {
            if (!((Enemy)enemyList[i]).IsVisible())
                continue;

            BarrageSpell barrageSpell = GetSpell<BarrageSpell>();
            barrageSpell.transform.position = transform.position;
            barrageSpell.Fire(enemyList[i].transform.position);
        }
    }
}
