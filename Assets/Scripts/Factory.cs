using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoodConveyor
{
    public class Factory : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _prefabs;
        [SerializeField] private float _timer = 1f;
        [SerializeField] private Vector2 _xRange = Vector2.zero;
        [SerializeField] private Vector2 _yRange = Vector2.zero;
        [SerializeField] private Vector2 _zRange = Vector2.zero;
        [SerializeField] private float _step = 0.1f;

        private float _currentTime = 0f;

        private void Update()
        {
            if (GameManager.IsPlay)
            {
                _currentTime += Time.deltaTime;

                if (_currentTime >= _timer)
                {
                    CreateRandomObject();
                    _currentTime = 0f;
                }
            }
        }

        private void CreateRandomObject()
        {
            if (_prefabs.Count == 0)
            {
                Debug.LogWarning("No prefabs available in the list.");
                return;
            }

            // Get Randon Prefab
            int randomIndex = Random.Range(0, _prefabs.Count);
            GameObject prefab = _prefabs[randomIndex];

            // Get Randon Position
            Vector3 position = transform.position;

            float xPosition = Random.Range(_xRange.x, _xRange.y);
            float yPosition = Random.Range(_yRange.x, _yRange.y);
            float zPosition = Random.Range(_zRange.x, _zRange.y);

            position.x += Mathf.Round(xPosition / _step) * _step;
            position.y += Mathf.Round(yPosition / _step) * _step;
            position.z += Mathf.Round(zPosition / _step) * _step;

            // Instantiate
            GameObject instance = Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
