using UnityEngine;
using UnityEngine.UI;
public class ItemPanel_ItemNode : MonoBehaviour
{
    Image m_Image;
    Transform m_Tf;
    void Start()
    {
        m_Tf = transform;
        m_Image = GetComponent<Image>();
    }

    void Update()
    {
        var index = m_Tf.GetSiblingIndex();
        if (index < InventoryMgr.m_List.Count)
        {
            m_Image.enabled = true;
            var key = InventoryMgr.m_List[index];
            var itemData = ItemDataMgr.GetData(key);
            m_Image.sprite = itemData.m_Sprite;
        }
        else
            m_Image.enabled = false;
    }
}
