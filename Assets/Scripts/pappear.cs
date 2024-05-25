using UnityEngine;

public class pappear : MonoBehaviour
{
    public GameObject obj; // 确保在编辑器中设置此引用

    void Start()
    {
        if (obj != null)
        {
            obj.SetActive(false);
        }
        else
        {
            Debug.LogError("obj is not set in the Inspector.");
        }
    }

    public void appear(GameObject obj)
    {
        Debug.Log("Appear method called with: " + obj.name);
        obj.SetActive(true);
        Debug.Log("Object active status: " + obj.activeSelf);
    }

}
