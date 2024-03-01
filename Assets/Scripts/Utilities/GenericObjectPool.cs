using CosmicCuration.Bullets;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static CosmicCuration.Bullets.BulletPool;


namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T : class
    {
        private class PooledItem<T2>
        {
            public T2 item;
            public bool isUsed;
        }

        private List<PooledItem<T>> pooledObjects = new List<PooledItem<T>>();


        protected T GetObj<U>() where U : T
        {
            if (pooledObjects.Count > 0)
            {
                PooledItem<T> item = pooledObjects.Find(item => !item.isUsed && item.item is T);
                if (item != null)
                {
                    item.isUsed = true;
                    return item.item;
                }
            }
            return CreateNewPooledObj<U>();
        }
        private T CreateNewPooledObj<U>() where U : T
        {
            PooledItem<T> newObj = new PooledItem<T>(); 
            newObj.item = CreateObj<U>();
            newObj.isUsed = true;
            pooledObjects.Add(newObj);
            return newObj.item;
        }

        public void ReturnObj<U>(T obj) where U : T
        {
            PooledItem<T> pooledObj = pooledObjects.Find(i => i.item.Equals(obj));
            pooledObj.isUsed = false;
        }

        protected virtual T CreateObj<U>() where U : T
        {
            throw new NotImplementedException("Child Class is not implemented this method");
        }
    }
}
