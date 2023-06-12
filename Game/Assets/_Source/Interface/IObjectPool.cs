using UnityEngine;

namespace _Source.Interface
{
    public interface IObjectPool
    {
        void InitObject(int count);
        public (GameObject, bool) GetObject();
    }
}