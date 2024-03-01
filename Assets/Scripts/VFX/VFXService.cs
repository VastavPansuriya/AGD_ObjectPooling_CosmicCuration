using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXService
    {
        private List<VFXData> vfxData = new List<VFXData>();
        private VFXPool vfxPool;
        public VFXService(VFXScriptableObject vfxScriptableObject)
        {
            vfxData = vfxScriptableObject.vfxData;
            vfxPool = new VFXPool(vfxData);
        }
        public void PlayVFXAtPosition(VFXType type, Vector2 spawnPosition)
        {
            VFXController vfxToPlay = vfxPool.GetVFX(type);
            vfxToPlay.Configure(spawnPosition);
        }

        public void ReturnToPool(VFXController vFXController)
        {
            vfxPool.ReturnObj(vFXController);
        }
    }
}