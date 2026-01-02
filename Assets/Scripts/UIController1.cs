using UnityEngine;
using UnityEngine.UI;

public class UIController1 : MonoBehaviour
{
    public Transform player; // 玩家物件
    public Transform destination; // A點位置物件
    public GameObject uiPromptLeft; // 向左UI提示介面物件
    public GameObject uiPromptRight; // 向右UI提示介面物件
    public GameObject uiPromptDeviation; // 偏離方向的UI提示介面物件
    public float deviationThreshold = 20f; // 偏離方向的閾值

    private bool isMoving; // 玩家是否正在移動
    private Vector3 lastPosition; // 上一幀的位置
    private float movementThreshold = 0.1f; // 位置變化的閾值
    //public CollisionHandler mapok;
    public int NumberCollisions = 0;//碰撞起始分數

    void Start()
    {
        isMoving = false;
        uiPromptLeft.SetActive(false);
        uiPromptRight.SetActive(false);
        uiPromptDeviation.SetActive(false);
        lastPosition = player.position;
        NumberCollisions = 0;
    }

    void Update()
    {
        // 玩家到達目的地，隱藏所有UI提示介面
        if (NumberCollisions == 1)
        {
            uiPromptDeviation.SetActive(false);
            uiPromptLeft.SetActive(false);
            uiPromptRight.SetActive(false);
        }

        // 檢查角色是否正在移動
        if (Vector3.Distance(player.position, lastPosition) > movementThreshold)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        lastPosition = player.position;

        if (isMoving)
        {
            Vector3 destinationDirection = destination.position - player.position;
            Vector3 forwardDirection = player.forward;
            Vector3 cross = Vector3.Cross(forwardDirection, destinationDirection);

            if (cross.y < 0f)
            {
                uiPromptLeft.SetActive(true);
                uiPromptRight.SetActive(false);
            }
            else
            {
                uiPromptLeft.SetActive(false);
                uiPromptRight.SetActive(true);
            }

          //  uiPromptDeviation.SetActive(false); // 玩家在移動時，隱藏偏離方向的UI提示介面
        }
        else
        {
            uiPromptLeft.SetActive(false);
            uiPromptRight.SetActive(false);

        }
    }

    public void SetIsMoving(bool moving)
    {
        isMoving = moving;
    }
}
