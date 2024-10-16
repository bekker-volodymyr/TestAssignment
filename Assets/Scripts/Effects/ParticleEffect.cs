using UnityEngine;

namespace TestAssignment.Effects
{
    public class ParticleEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

        private ParticleManager _manager;
        private ParticleType _type;
        public ParticleType Type => _type;

        private void Start()
        {
            var main = _particleSystem.main;
            main.stopAction = ParticleSystemStopAction.Callback;

            main.useUnscaledTime = true;
        }

        public void SetManager(ParticleManager manager)
        {
            _manager = manager;
        }

        public void Play()
        {
            if (_particleSystem.isPlaying)
            {
                _particleSystem.Stop();
            }

            _particleSystem.Play(true);
        }

        public void OnParticleSystemStopped()
        {
            _manager.ReturnParticle(this);
        }
    }
}
