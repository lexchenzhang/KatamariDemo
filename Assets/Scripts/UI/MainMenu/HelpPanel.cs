using UnityEngine;
using com.lex.katamari.util.ui;

namespace com.lex.katamari.ui.mainmenu
{
    [RequireComponent(typeof(UIUtil))]
    public class HelpPanel : MonoBehaviour
    {
        private UIUtil _uiUtil;
        private RectTransform _mRectTransform;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _uiUtil = GetComponent<UIUtil>();
            _mRectTransform = GetComponent<RectTransform>();
        }

        public void Open()
        {
            LeanTweenExt.LeanAlpha(GetComponent<CanvasGroup>(), 1, 0.1f);
            _uiUtil.InitComV(_mRectTransform, 0f);
        }

        public void Close()
        {
            LeanTweenExt.LeanAlpha(GetComponent<CanvasGroup>(), 0, 0.1f);
            _uiUtil.InitComV(_mRectTransform, 600f);
        }
    }
}
