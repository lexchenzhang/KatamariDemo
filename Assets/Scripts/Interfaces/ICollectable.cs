using UnityEngine;

public interface ICollectable
{
    public void StickToTheBall(GameObject gameObject);
    public int GetScore();
    public string GetName();
}
