using UnityEngine;

public class CopyObjectOnDrop : MonoBehaviour
{
    public GameObject objectToCopy;

    private void Start()
    {
        // �}�l�����ê���
        objectToCopy.SetActive(false);
    }

    public void CopyObject()
    {
        // �ƻs�������ܦb���w���ͦ��I
        objectToCopy.SetActive(true);
    }
}
