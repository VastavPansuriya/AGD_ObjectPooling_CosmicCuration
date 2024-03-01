using CosmicCuration.Bullets;
using CosmicCuration.Utilities;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;

namespace CosmicCuration.VFX
{
    public class VFXPool : GenericObjectPool<VFXController>
    {
        private VFXView vfxView;
        private List<VFXData> vfxData;

        public VFXPool(List<VFXData> vfxData)
        {
            this.vfxData = vfxData;
        }

        public VFXController GetVFX(VFXType type)
        {
            VFXView prefabToSpawn = vfxData.Find(item => item.type == type).prefab;
            vfxView = prefabToSpawn;
            return GetObj<VFXController>();
        }
        protected override VFXController CreateObj<T>() => new VFXController(vfxView);
    }
}
