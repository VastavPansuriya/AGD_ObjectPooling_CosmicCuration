using CosmicCuration.Utilities;
using UnityEngine;

namespace CosmicCuration.PowerUps
{
    public class PowerUpPool : GenericObjectPool<PowerUpController>
    {

        private PowerUpData powerUpData;

        public PowerUpController GetPowerUpController<T>(PowerUpData powerUpData) where T : PowerUpController
        {
            this.powerUpData = powerUpData;
            return GetObj<T>();
        }

        protected override PowerUpController CreateObj<U>()
        {
            if (typeof(U) == typeof(Shield))
            {
                return new Shield(powerUpData);
            }
            else if (typeof(U) == typeof(RapidFire))
            {
                return new RapidFire(powerUpData);
            }
            else if (typeof(U) == typeof(DoubleTurret))
            {
                return new DoubleTurret(powerUpData);
            }
            else
            {
                Debug.LogError("Returning null");   
                return null;
            }
        }
    }
}
