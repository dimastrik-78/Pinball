using System.Collections.Generic;
using _Source.Interface;
using UnityEngine;

namespace _Source.BonusSystem
{
    public class BonusPool : IObjectPool
    {
        private readonly GameObject _prefBall;
        private readonly List<GameObject> _bonusList = new();

        public BonusPool(GameObject prefBall)
        {
            _prefBall = prefBall;
        }
        
        public void InitObject(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _bonusList.Add(Object.Instantiate(_prefBall));
            }
        }
        
        public (GameObject, bool) GetObject()
        {
            (GameObject, bool) check = CheckPool();
            if (!check.Item2)
            {
                return (null, false);
            }
            
            check.Item1.SetActive(true);
            return (check.Item1, true);
        }

        private (GameObject, bool) CheckPool()
        {
            for (int i = 0; i < _bonusList.Count; i++)
            {
                if (!_bonusList[i].activeSelf)
                {
                    return (_bonusList[i], true);
                }
            }

            return (null, false);
        }
    }
}