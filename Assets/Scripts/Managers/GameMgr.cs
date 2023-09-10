using UnityEngine;

public class GameMgr : MonoBehaviour
{
    // stage root for all subcomponents
    [SerializeField] private GameObject stageRoot;
    // item root for all collectable items
    [SerializeField] private GameObject itemRoot;
    // stage plane prefab to set up the stage
    [SerializeField] private GameObject stagePlane;
    // stage blocker prefab to set up the stage
    [SerializeField] private GameObject stageBlocker;
    // collectable prefabs
    [SerializeField] private GameObject[] collectableItems;

    void Awake()
    {
        // throw an error if serialize field not asigned
        if (stageRoot == null) throw new UnassignedReferenceException("stage root in GameMgr not set");
        if (itemRoot == null) throw new UnassignedReferenceException("item root in GameMgr not set");
        if (stagePlane == null) throw new UnassignedReferenceException("stage plane in GameMgr not set");
        if (stageBlocker == null) throw new UnassignedReferenceException("stage blocker in GameMgr not set");
        if (collectableItems.Length == 0) throw new UnassignedReferenceException("collectable items array in GameMgr not set");
    }

    void Start()
    {
        initStage();
        initCollectableItems();
    }

    private void initStage()
    {
        // setup a 3 by 3 stage for the ball to rolling
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject sp = Instantiate(stagePlane, new Vector3((i - 1) * 10f, 0f, (j - 1) * 10f), Quaternion.identity);
                sp.transform.parent = stageRoot.transform;
            }
        }

        // setup blockers to prevent ball fall off the edge
        // create blockers by looping four times (top, bottom, left, right)
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                // rotate the blocker if i == 3 (left) or i == 4 (right)
                Quaternion angle = i / 2 == 0 ? Quaternion.identity : Quaternion.Euler(new Vector3(0, 90, 0));
                // calculate blocker position based on i and j
                Vector3 position = i / 2 == 0 ? new Vector3((j - 1) * 10f, 0f, i % 2 == 0 ? 15f : -15f) : new Vector3(i % 2 == 0 ? 15f : -15f, 0f, (j - 1) * 10f);
                GameObject sp = Instantiate(stageBlocker, position, angle);
                sp.transform.parent = stageRoot.transform;
            }
        }
    }

    private void initCollectableItems()
    {
        int spawnMatrixSize = 20;
        float spawnGap = 1.3f;

        for (int i = 0; i < spawnMatrixSize; i++)
        {
            for (int j = 0; j < spawnMatrixSize; j++)
            {
                GameObject ci = Instantiate(collectableItems[Random.Range(0, collectableItems.Length)], new Vector3((i - spawnMatrixSize/2) * spawnGap, 0f, (j - spawnMatrixSize/2) * spawnGap), Quaternion.identity);
                ci.transform.parent = itemRoot.transform;
            }
        }
    }
}
