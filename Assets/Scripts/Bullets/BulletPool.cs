
using CosmicCuration.Utilities;

namespace CosmicCuration.Bullets
{
    public class BulletPool : GenericObjectPool<BulletController>
    {
        private BulletView bulletPrefab;
        private BulletScriptableObject bulletSO;

        public BulletPool(BulletView bulletPrefab, BulletScriptableObject bulletSO)
        {
            this.bulletPrefab = bulletPrefab;
            this.bulletSO = bulletSO;
        }

        public BulletController GetBullet() => GetObj();

        protected override BulletController CreateObj() => new BulletController(bulletPrefab, bulletSO);
    }
}
