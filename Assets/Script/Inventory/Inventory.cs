using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool inventoryActivated = false;// �κ��丮 Ȱ��ȭ ����. true�� �Ǹ� ī�޶� �����Ӱ� �ٸ� �Է��� ���� ���̴�.

    [SerializeField]
    private GameObject go_InventoryBase; //Inventory_Base �̹���
    [SerializeField]
    private GameObject go_SlotsParent; //Slot���� �θ��� Grod Setting

    private Slot[] slots; //���Ե� �迭


    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
    }
    private void Update()
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
        go_InventoryBase.SetActive(true);
    }

    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
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
}
