using System.Collections.Generic;
using UnityEngine;

namespace TestAssignment.Enemies
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private Enemy _objPrefab;
        [SerializeField] private int _initSize = 10;

        private Queue<Enemy> _pool = new Queue<Enemy>();

        void Start()
        {
            for (int i = 0; i < _initSize; i++)
            {
                Enemy obj = Instantiate(_objPrefab);
                obj.gameObject.SetActive(false);
                _pool.Enqueue(obj);
            }
        }

        public Enemy GetObject()
        {
            if (_pool.Count > 0)
            {
                Enemy obj = _pool.Dequeue();
                obj.gameObject.SetActive(true);
                return obj;
            }
            else
            {
                Enemy obj = Instantiate(_objPrefab);
                return obj;
            }
        }

        public void ReturnObject(Enemy obj)
        {
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }
    }
}