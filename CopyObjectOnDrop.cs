using UnityEngine;

public class CopyObjectOnDrop : MonoBehaviour
{
    public GameObject objectToCopy;

    private void Start()
    {
        // 開始時隱藏物體
        objectToCopy.SetActive(false);
    }

    public void CopyObject()
    {
        // 複製物體並顯示在指定的生成點
        objectToCopy.SetActive(true);
    }
}
