using System.Collections;
using UnityEngine;

namespace LevelManagement.Utility
{
    public class TransitionFader : ScreenFader
    {
        [SerializeField] private float _transitionLifetime = 0f;
        [SerializeField] private float _delay = 0.3f;
        public float Delay => _delay;

        protected void Awake()
        {
            _transitionLifetime = Mathf.Clamp(_transitionLifetime, FadeOnDuration + FadeOffDuration + _delay, 10f);
        }

        public void Play()
        {
            StartCoroutine(nameof(PlayRoutine));
        }

        private IEnumerator PlayRoutine()
        {
            SetAlpha(_clearAlpha);
            yield return new WaitForSeconds(_delay);
            FadeOn();
            
            var onTime = _transitionLifetime - (FadeOffDuration + _delay);
            yield return new WaitForSeconds(onTime);
            FadeOff();
            
            Destroy(this.gameObject, FadeOffDuration);
        }

        public static void PlayTransition(TransitionFader transitionFaderPrefab)
        {
            var transitionFader = Instantiate(transitionFaderPrefab, Vector3.zero, Quaternion.identity);
            transitionFader.Play();
        }
    }
}
