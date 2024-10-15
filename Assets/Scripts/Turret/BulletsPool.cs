using System.Collections.Generic;
using UnityEngine;

namespace TestAssignment.Turret
{
    public class BulletsPool : MonoBehaviour
    {
        [SerializeField] private Bullet _objPrefab;
        [SerializeField] private int _initSize = 10;

        private Queue<Bullet> _pool = new Queue<Bullet>();

        void Start()
        {
            for (int i = 0; i < _initSize; i++)
            {
                Bullet obj = Instantiate(_objPrefab);
                obj.gameObject.SetActive(false);
                _pool.Enqueue(obj);
            }
        }

        public Bullet GetObject()
        {
            if (_pool.Count > 0)
            {
                Bullet obj = _pool.Dequeue();
                obj.gameObject.SetActive(true);
                return obj;
            }
            else
            {
                Bullet obj = Instantiate(_objPrefab);
                return obj;
            }
        }

        public void ReturnObject(Bullet obj)
        {
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }
    }
}