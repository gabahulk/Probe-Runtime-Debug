using UnityEngine;

namespace Probe.Example.Scripts
{
    public class SelfDestruct : MonoBehaviour
    {
        private float _spawnInterval = -1;
        private float _timer;
        void Update()
        {
            _timer += Time.deltaTime;
            if (!(_timer >= _spawnInterval) || Mathf.Approximately(_spawnInterval, -1)) return;
            _timer = 0f;
            Destroy(gameObject);
        }

        public void SetDestructionTime(float time)
        {
            _spawnInterval = time;
        }
    }
}
