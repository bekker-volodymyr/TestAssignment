using TestAssignment.Utils;
using UnityEngine;

namespace TestAssignment.Effects
{
    public enum ParticleType
    {
        EnemyDeath,
        CarExplosion
    }

    public class ParticleManager : MonoBehaviour
    {
        private static ParticleManager _instance;
        public static ParticleManager Instance => _instance;

        [SerializeField] private ParticleEffect _deathParticlesPrefab;
        private ObjectPool<ParticleEffect> _deathParticles;

        [SerializeField] private ParticleSystem _carExplosionParticles;

        private void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
            _deathParticles = new ObjectPool<ParticleEffect>(_deathParticlesPrefab);
        }

        public void PlayParticle(ParticleType type, Vector3 position)
        {
            switch (type)
            {
                case ParticleType.EnemyDeath:
                    PlayeEnemyDeath(position);
                    break;
                case ParticleType.CarExplosion:
                    PlayCarExplosion(position);
                    break;
                default: Debug.Log($"Unknown particle type: {type}"); return;
            }
        }

        private void PlayeEnemyDeath(Vector3 position)
        {
            ParticleEffect particleEffect;
            particleEffect = _deathParticles.GetObject();
            particleEffect.gameObject.transform.position = position;
            particleEffect.SetManager(this);
            particleEffect.Play();
        }

        private void PlayCarExplosion(Vector3 position)
        {
            _carExplosionParticles.transform.position = position;

            _carExplosionParticles.Play(true);
        }

        public void ReturnParticle(ParticleEffect effect)
        {
            switch (effect.Type)
            {
                case ParticleType.EnemyDeath: _deathParticles.ReturnObject(effect); break;
                default: Debug.Log($"Unknown particle type: {effect.Type}"); break;
            }
        }
    }
}
