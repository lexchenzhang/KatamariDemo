using UnityEngine;

namespace com.lex.katamari.util.ui
{
    public class UIUtil : MonoBehaviour
    {
        [SerializeField]
        [Range(0.1f, 1.0f)]
        private float _eff_dur;

        [SerializeField]
        [Range(0.1f, 3.0f)]
        private float _eff_delay;

        public void InitComH(RectTransform myRectTransform, float desX)
        {
            LeanTweenExt.LeanMoveX(myRectTransform, desX, _eff_dur).setDelay(_eff_delay).setEaseOutElastic();
        }

        public void InitComV(RectTransform myRectTransform, float desY)
        {
            LeanTweenExt.LeanMoveY(myRectTransform, desY, _eff_dur).setDelay(_eff_delay).setEaseOutElastic();
        }
    }
}
