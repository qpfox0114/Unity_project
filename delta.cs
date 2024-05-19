using UnityEngine;
using UnityEngine.EventSystems;

public class Delta : MonoBehaviour, IDropHandler
{
    public GameObject myObject;
    public float offset = 0.1f;

    // �վ�o���ܶq�ӱ���Ԫ����t��
    public float stretchSpeed = 1.0f;
    // �̤j����
    public float maxLength = 10.0f;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        if (dropped != null)
        {
            if (dropped.name == "Imagelarge")
            {
                EnlargeObject();
            }
            else if (dropped.name == "derivative")
            {
                ShrinkObject();
            }
            else if (dropped.name == "rotate")
            {
                RotateObject();
            }
            else if (dropped.name == "long")
            {
                StretchObject();
            }
            else if (dropped.name == "disappear")
            {
                Destroy(myObject); // �u���b��� "disappear" �ɤ~�P������
            }
        }
    }

    void ShrinkObject()
    {
        if (myObject != null)
        {
            myObject.transform.localScale = new Vector3(myObject.transform.localScale.x - offset,
                                                         myObject.transform.localScale.y - offset,
                                                         myObject.transform.localScale.z - offset);
        }
    }

    void EnlargeObject()
    {
        if (myObject != null)
        {
            myObject.transform.localScale = new Vector3(myObject.transform.localScale.x + offset,
                                                         myObject.transform.localScale.y + offset,
                                                         myObject.transform.localScale.z + offset);
        }
    }

    void RotateObject()
    {
        if (myObject != null)
        {
            myObject.transform.Rotate(Vector3.forward, 90f);
        }
    }

    void StretchObject()
    {
        if (myObject != null)
        {
            // ��������e�� x �M y �b����
            float currentLengthX = myObject.transform.localScale.x;
            float currentLengthY = myObject.transform.localScale.y;

            // �P�_���Ӷb�V�����ק��
            if (currentLengthX >= currentLengthY)
            {
                // �p�G x �b���ק���A�ˬd�O�_�ݭn�Ԫ��éԪ� x �b
                if (currentLengthX < maxLength)
                {
                    myObject.transform.localScale += new Vector3(stretchSpeed * Time.deltaTime, 0, 0);
                }
            }
            else
            {
                // �p�G y �b���ק���A�ˬd�O�_�ݭn�Ԫ��éԪ� y �b
                if (currentLengthY < maxLength)
                {
                    myObject.transform.localScale += new Vector3(0, stretchSpeed * Time.deltaTime, 0);
                }
            }
        }
    }
}