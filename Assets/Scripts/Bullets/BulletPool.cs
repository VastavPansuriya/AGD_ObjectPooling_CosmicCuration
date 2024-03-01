using System.Collections.Generic;

namespace CosmicCuration.Bullets
{
    public class BulletPool
    {
        public class PooledBullet
        {
            public BulletController bullet;
            public bool isUsed;
        }

        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        private List<PooledBullet> pooledBullets = new List<PooledBullet>();

        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject)
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }

        public BulletController GetBullet()
        {
            if (pooledBullets.Count > 0)
            {
                PooledBullet pooledBullet = pooledBullets.Find(item => !item.isUsed);
                if (pooledBullet != null)
                {
                    pooledBullet.isUsed = true;
                    return pooledBullet.bullet;
                }
            }
            return CreateNewBullet();
            
        }

        public BulletController CreateNewBullet()
        {
            PooledBullet bullet = new PooledBullet();
            bullet.bullet = new BulletController(bulletView, bulletScriptableObject);
            bullet.isUsed = true;
            pooledBullets.Add(bullet);
            return bullet.bullet;
        }

        public void ReturnToBulletPool(BulletController bulletController)
        {
            PooledBullet pooledBullet = pooledBullets.Find(item => item.bullet.Equals(bulletController));
            pooledBullet.isUsed = false;
        }
    }
}

