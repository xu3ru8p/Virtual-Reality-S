using UnityEngine;

public class FlagController1 : MonoBehaviour
{
    public GameObject flag;
    public GameObject map;

    private bool isFlagPickedUp = false;

    private void Start()
    {
        // 一開始顯示map物件
        map.SetActive(true);
    }

    private void Update()
    {
        // 偵測Oculus Quest 2搖桿按鈕的狀態
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            if (!isFlagPickedUp)
            {
                // 抓起Flag時，隱藏map物件
                flag.SetActive(false);
                isFlagPickedUp = true;
            }
            else
            {
                // 放下Flag時，顯示map物件
                flag.SetActive(true);
                isFlagPickedUp = false;
            }
        }
    }
}
