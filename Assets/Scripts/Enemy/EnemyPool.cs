using CosmicCuration.Bullets;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Enemy
{
    public class EnemyPool
    {
        private class PooledEnemy
        {
            public EnemyController enemy;
            public bool isUsed;
        }

        private EnemyView enemyView;
        private EnemyData enemyData;

        private List<PooledEnemy> pooledEnemies = new List<PooledEnemy>();

        public EnemyPool(EnemyView enemyView, EnemyData enemyData)
        {
            this.enemyView = enemyView;
            this.enemyData = enemyData;
        }

        public EnemyController GetEnemy()
        {
            if (pooledEnemies.Count > 0)
            {
                PooledEnemy pooledEnemy = pooledEnemies.Find(item => !item.isUsed);
                if (pooledEnemy != null)
                {
                    pooledEnemy.isUsed = true;
                    return pooledEnemy.enemy;
                }
            }
            return CreateNewEnemy();

        }

        public EnemyController CreateNewEnemy()
        {
            PooledEnemy enemy = new PooledEnemy();
            enemy.enemy = new EnemyController(enemyView,enemyData);
            enemy.isUsed = true;
            pooledEnemies.Add(enemy);
            return enemy.enemy;
        }

        public void ReturnToEnemyPool(EnemyController bulletController)
        {
            PooledEnemy pooledBullet = pooledEnemies.Find(item => item.enemy.Equals(bulletController));
            pooledBullet.isUsed = false;
        }
    }
}
