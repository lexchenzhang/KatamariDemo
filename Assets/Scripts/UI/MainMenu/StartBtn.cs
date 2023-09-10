using com.lex.katamari.util.scene;
using UnityEngine;

namespace com.lex.katamari.ui.mainmenu
{
    public class StartBtn : MonoBehaviour
    {
        public void StartGame()
        {
            SceneMgr.Instance.LoadLevel(SceneList.GAME, (levelName) => {
                SceneMgr.Instance.UnLoadLevel(SceneList.MENU);
            });
        }
    }
}
