using com.lex.katamari.util.scene;
using UnityEngine;

public class Entry : MonoBehaviour
{
    void Start()
    {
        SceneMgr.Instance.LoadLevel(SceneList.MENU, (levelName) => { });
    }
}
