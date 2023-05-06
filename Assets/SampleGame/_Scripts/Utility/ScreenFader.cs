using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement.Utility
{
    public class ScreenFader : MonoBehaviour
    {
        [SerializeField] private float _solidAlpha = 1f;
        [SerializeField] private float _clearAlpha = 0f;
        [SerializeField] private float _fadeDuration = 2f;

        [SerializeField] private MaskableGraphic[] _graphicsToFade;

        private void SetAlpha(float alphaValue)
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
            Fade(_clearAlpha, _fadeDuration);
        }

        public void FadeOn()
        {
            SetAlpha(_clearAlpha);
            Fade(_solidAlpha, _fadeDuration);
        }
    }
}