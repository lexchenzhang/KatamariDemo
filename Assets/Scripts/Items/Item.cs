using UnityEngine;

public class Item : MonoBehaviour, ICollectable
{
    [SerializeField] private SOItems _item;

    public int GetScore()
    {
        if (_item == null) return 0;
        return _item.itemScore;
    }

    public string GetName()
    {
        if (_item == null) return "null";
        return _item.itemName;
    }

    public void StickToTheBall(GameObject gameObject)
    {
        // remove the collider when it sticky to the big ball
        Destroy(gameObject.GetComponent<BoxCollider>());
        // set pickable item as ball's child to stick them together
        transform.parent = gameObject.transform;
    }
}
