using UnityEngine;

namespace Probe.Example.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private float spawnInterval = 1f;
        [SerializeField] private float spawnSelfDestruct = 5f;
        [SerializeField] private bool enabledSpawning = true;

        private float _timer;

        void Update()
        {
            if (!enabledSpawning || prefab == null)
                return;

            _timer += Time.deltaTime;
            if (_timer >= spawnInterval)
            {
                _timer = 0f;
                Spawn();
            }
        }

        void Spawn()
        {
            var obj = Instantiate(
                prefab,
                transform.position + Random.insideUnitSphere * 2f,
                Quaternion.identity
            );
            obj.GetComponent<SelfDestruct>().SetDestructionTime(spawnSelfDestruct);
        }

        // Expor para o Probe
        public float SpawnInterval
        {
            get => spawnInterval;
            set => spawnInterval = Mathf.Max(0.1f, value);
        }
        
        public float SelfDestructInterval
        {
            get => spawnSelfDestruct;
            set => spawnSelfDestruct = Mathf.Max(0.1f, value);
        }

        public bool EnabledSpawning
        {
            get => enabledSpawning;
            set => enabledSpawning = value;
        }
    }
}