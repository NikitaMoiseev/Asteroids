using UnityEngine;

namespace App.Session.Config
{
    [CreateAssetMenu(menuName = "ScriptableObjects/SessionConfig", fileName = "SessionConfig")]
    public class SessionConfigSO : ScriptableObject
    {
        [SerializeField] private int _minAsteroidsCoint;
        [SerializeField] private int _maxAsteroidsCoint;
        [SerializeField] private float _minTimerUfoSpawn;
        [SerializeField] private float _maxTimerUfoSpawn;

        public int MinAsteroidsCoint => _minAsteroidsCoint;
        public int MaxAsteroidsCoint => _maxAsteroidsCoint;
        public float RandomUfoSpawnTimer => Random.Range(_minTimerUfoSpawn, _maxTimerUfoSpawn);
    }
}