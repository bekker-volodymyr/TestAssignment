using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _objPrefab;
    [SerializeField] private int _initSize = 10;

    private Queue<GameObject> _pool = new Queue<GameObject>();

    public event Action<GameObject> ObjectReturnedEvent;

    void Start()
    {
        for (int i = 0; i < _initSize; i++)
        {
            GameObject obj = Instantiate(_objPrefab);
            obj.SetActive(false);
            _pool.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        if (_pool.Count > 0)
        {
            GameObject obj = _pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(_objPrefab);
            return obj;
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        _pool.Enqueue(obj);
        ObjectReturnedEvent?.Invoke(obj);
    }
}
