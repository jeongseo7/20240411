using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;


// item
public class NewInven : MonoBehaviour
{
    // UI Inventory
    public static bool inventoryActivated = false;// 인벤토리 활성화 여부. true가 되면 카메라 움직임과 다른 입력을 막을 것이다.
    [SerializeField]
    private GameObject go_InventoryBase; //Inventory_Base 이미지
    [SerializeField]
    private GameObject go_SlotsParent; //Slot들의 부모인 Grod Setting
    private Slot[] slots; //슬롯들 배열
    public Dictionary<string, Item> inventoryItems;   // 인벤토리 내 아이템

    

    // Update is called once per frame

    private void Awake()
    {
        inventoryItems = new Dictionary<string, Item>();
    }
    void Update()
    {
        TryOpenInventory();
    }

    private void TryOpenInventory()
    {

        if (Input.GetKeyUp(KeyCode.I))
        {
            inventoryActivated = !inventoryActivated;

            if (inventoryActivated)
                OpenInventory();
            else
                CloseInventory();
        }
    }
    private void OpenInventory()
    {
        go_InventoryBase.SetActive(true); // UI 활성화
    }
    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);// UI 비활성화
    }

    public void AcquireItem(Item _item, int _count = 1)
    {
        if (Item.ItemType.Equipment != _item.itemtype)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {

                    if (slots[i].item.itemName == _item.itemName)
                    {
                        slots[i].SetSlotCount(_count);
                        return;
                    }

                }

            }
        }


        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                slots[i].AddItem(_item, _count);
                return;
            }

        }
    }

    private void Ininventory(Item item)
    {
        foreach (var i in PlayerItem.Instance.inventoryItems)
        {

        }
    } 

}
