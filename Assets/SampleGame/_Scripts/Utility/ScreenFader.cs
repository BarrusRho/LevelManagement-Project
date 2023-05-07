using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement.Utility
{
    public class ScreenFader : MonoBehaviour
    {
        [SerializeField] protected float _solidAlpha = 1f;
        [SerializeField] protected float _clearAlpha = 0f;
        [SerializeField] private float _fadeOnDuration = 2f;
        [SerializeField] private float _fadeOffDuration = 2f;
        public float FadeOnDuration => _fadeOnDuration;
        public float FadeOffDuration => _fadeOffDuration;

        [SerializeField] private MaskableGraphic[] _graphicsToFade;

        protected void SetAlpha(float alphaValue)
        {
            foreach (var graphic in _graphicsToFade)
            {
                if (graphic != null)
                {
                    graphic.canvasRenderer.SetAlpha(alphaValue);
                }
            }
        }

        private void Fade(float targetAlpha, float duration)
        {
            foreach (var graphic in _graphicsToFade)
            {
                if (graphic != null)
                {
                    graphic.CrossFadeAlpha(targetAlpha, duration, true);
                }
            }
        }

        public void FadeOff()
        {
            SetAlpha(_solidAlpha);
            Fade(_clearAlpha, _fadeOffDuration);
        }

        public void FadeOn()
        {
            SetAlpha(_clearAlpha);
            Fade(_solidAlpha, _fadeOnDuration);
        }
    }
}