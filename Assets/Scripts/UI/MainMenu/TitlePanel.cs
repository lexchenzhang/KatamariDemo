using UnityEngine;
using com.lex.katamari.util.ui;

namespace com.lex.katamari.ui.mainmenu
{
    [RequireComponent(typeof(UIUtil))]
    public class TitlePanel : MonoBehaviour
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

        public void Start()
        {
            _uiUtil.InitComH(_mRectTransform, 0f);
        }

        public void Close()
        {
            _uiUtil.InitComH(_mRectTransform, -1000f);
        }
    }
}