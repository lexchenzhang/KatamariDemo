using com.lex.katamari.util.scene;
using UnityEngine;

namespace com.lex.katamari.ui.gamemenu
{
    public class BackToMenuBtn : MonoBehaviour
    {
        public void BackToMenu()
        {
            SceneMgr.Instance.LoadLevel(SceneList.MENU, (levelName) =>
            {
                SceneMgr.Instance.UnLoadLevel(SceneList.GAME);
            });
        }
    }
}
