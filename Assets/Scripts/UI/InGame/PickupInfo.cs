using UnityEngine;
using com.lex.katamari.util.ui;
using TMPro;

namespace com.lex.katamari.ui.gamemenu
{
    [RequireComponent(typeof(UIUtil))]
    public class PickupInfo : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _infoComponent;
        private UIUtil _uiUtil;
        private RectTransform _mRectTransform;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            if (_infoComponent == null) throw new UnassignedReferenceException("info component in PickupInfo not set");
            _uiUtil = GetComponent<UIUtil>();
            _mRectTransform = GetComponent<RectTransform>();
        }

        public void Open(string itemName)
        {
            _infoComponent.text = $"{itemName}!!";
            LeanTweenExt.LeanAlpha(GetComponent<CanvasGroup>(), 1, 0.1f);
            _uiUtil.InitComH(_mRectTransform, 0f);
            Invoke("Close", .5f);
        }

        public void Close()
        {
            LeanTweenExt.LeanAlpha(GetComponent<CanvasGroup>(), 0, 0.1f);
            _uiUtil.InitComH(_mRectTransform, -400f);
        }
    }
}