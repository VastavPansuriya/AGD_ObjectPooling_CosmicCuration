using CosmicCuration.Utilities;
using System.Collections.Generic;

namespace CosmicCuration.Enemy
{
    public class EnemyPool : GenericObjectPool<EnemyController>
    {
        private EnemyView enemyPrefab;
        private EnemyData enemyData;

        public EnemyPool(EnemyView enemyPrefab, EnemyData enemyData)
        {
            this.enemyPrefab = enemyPrefab;
            this.enemyData = enemyData;
        }

        public EnemyController GetEnemy() => GetObj<EnemyController>();

        protected override EnemyController CreateObj<T>() => new EnemyController(enemyPrefab, enemyData);
    }
}
