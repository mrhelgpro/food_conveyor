using System.Collections.Generic;
using _Game.Scripts.Services;
using UnityEngine;

namespace _Game.Scripts
{
    public class Factory : MonoBehaviour
    {
        [SerializeField] private List<GameObject> prefabs;
        [SerializeField] private float timer = 1f;
        [SerializeField] private Vector2 xRange = Vector2.zero;
        [SerializeField] private Vector2 yRange = Vector2.zero;
        [SerializeField] private Vector2 zRange = Vector2.zero;
        [SerializeField] private float step = 0.1f;

        private float _currentTime;

        private void Update()
        {
            if (GameManager.IsPlay)
            {
                _currentTime += Time.deltaTime;

                if (_currentTime >= timer)
                {
                    CreateRandomObject();
                    _currentTime = 0f;
                }
            }
        }

        private void CreateRandomObject()
        {
            if (prefabs.Count == 0) return;
        
            int randomIndex = Random.Range(0, prefabs.Count);
            GameObject prefab = prefabs[randomIndex];
        
            Vector3 position = transform.position;

            float xPosition = Random.Range(xRange.x, xRange.y);
            float yPosition = Random.Range(yRange.x, yRange.y);
            float zPosition = Random.Range(zRange.x, zRange.y);

            position.x += Mathf.Round(xPosition / step) * step;
            position.y += Mathf.Round(yPosition / step) * step;
            position.z += Mathf.Round(zPosition / step) * step;
        
            GameObject instance = Instantiate(prefab, position, Quaternion.identity);
            instance.transform.parent = transform;
        }
    }
}