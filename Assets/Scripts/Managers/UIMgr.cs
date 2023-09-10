using com.lex.katamari.ui.gamemenu;
using TMPro;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreComponent;
    [SerializeField] GameObject _infoPanelObject;

    private void Awake()
    {
        if (_scoreComponent == null) throw new UnassignedReferenceException("score component in UIMgr not set");
        if (_infoPanelObject == null) throw new UnassignedReferenceException("info panel obj in UIMgr not set");
        EventMgr.current.OnItemPickedUpTriggerEnter += OnItemPickedUp;
    }

    private int _totalScore;

    private void UpdateScore(int score)
    {
        _totalScore += score;
        _scoreComponent.text = $"SCORE: {_totalScore}";
    }

    private void UpdatePickupInfoPanel(string itemName)
    {
        _infoPanelObject.GetComponent<PickupInfo>().Open(itemName);
    }

    // only update the score when item picked up
    // this event driven update reduce CPU usage a lot
    private void OnItemPickedUp(ICollectable item)
    {
        UpdateScore(item.GetScore());
        UpdatePickupInfoPanel(item.GetName());
    }
}
