using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float radius;  // ������ ������ ������ �ִ� ������ (�� raycast)

    private bool pickupActivated = false;  // ������ ���� �����ҽ� True 

    private RaycastHit2D hitInfo;  // �浹ü ���� ����(item)

    [SerializeField]
    private LayerMask layerMask;  // Ư�� ���̾ ���� ������Ʈ�� ���ؼ��� ������ �� �־�� �Ѵ�.


    void Update()
    {
        CheckItem();
        TryAction();
    }

    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();
            CanPickUp();
        }
    }

    private void CheckItem()
    {   
        // (���� ��ġ, ������, ����, �Ÿ�(�����̶� 0), �浹�� Ȯ���� ���̾� )
        hitInfo = Physics2D.CircleCast(transform.position, radius, Vector2.zero, 0, layerMask);

        //�浹ü�� ������
        if (hitInfo.collider != null)
        {   // �浹ü�� tag�� Item�϶�
            if (hitInfo.collider.CompareTag("Item"))
            {   
                ItemInfoAppear();
            }
        }
        else
            ItemInfoDisappear();
    }

    private void ItemInfoAppear()
    {  //�ֿ� �� �ִ� ���� = true
        pickupActivated = true;
    }

    private void ItemInfoDisappear()
    {  //�ֿ� �� �ִ� ���� = false
        pickupActivated = false;
    }

    //�ݴ� �Լ�
    private void CanPickUp()
    {  //�ֿ� �� �ִ� ���� = true �̸�
        if (pickupActivated)
        {
            if (hitInfo.collider != null)
            {
                Debug.Log(hitInfo.transform.GetComponent<PickupItem>().item.itemName + " ȹ�� �߽��ϴ�.");  // �κ��丮 �ֱ�

                pickUp();
                Destroy(hitInfo.collider.gameObject);//�������� �����Ѵ�
                ItemInfoDisappear();
            }
        }
    }
    //�ݴ� �������� ������ �÷��̾� �κ��丮�� ����
    private void pickUp()
    {
        string itemName = hitInfo.transform.GetComponent<PickupItem>().item.itemName; // ������ �̸��� ������ ����
        Item item = hitInfo.transform.GetComponent<PickupItem>().item; // �������� ������ ������ ����
        PlayerItem.Instance.inventoryItems.Add(itemName,item); // �迭�� �߰��ϴ� ����
    }



}

