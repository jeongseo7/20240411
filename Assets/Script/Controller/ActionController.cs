using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float radius;  // 아이템 습득이 가능한 최대 반지름 (원 raycast)

    private bool pickupActivated = false;  // 아이템 습득 가능할시 True 

    private RaycastHit2D hitInfo;  // 충돌체 정보 저장(item)

    [SerializeField]
    private LayerMask layerMask;  // 특정 레이어를 가진 오브젝트에 대해서만 습득할 수 있어야 한다.


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
        // (시작 위치, 반지름, 방향, 거리(원형이라 0), 충돌을 확인할 레이어 )
        hitInfo = Physics2D.CircleCast(transform.position, radius, Vector2.zero, 0, layerMask);

        //충돌체가 있을때
        if (hitInfo.collider != null)
        {   // 충돌체의 tag가 Item일때
            if (hitInfo.collider.CompareTag("Item"))
            {   
                ItemInfoAppear();
            }
        }
        else
            ItemInfoDisappear();
    }

    private void ItemInfoAppear()
    {  //주울 수 있는 상태 = true
        pickupActivated = true;
    }

    private void ItemInfoDisappear()
    {  //주울 수 있는 상태 = false
        pickupActivated = false;
    }

    //줍는 함수
    private void CanPickUp()
    {  //주울 수 있는 상태 = true 이면
        if (pickupActivated)
        {
            if (hitInfo.collider != null)
            {
                Debug.Log(hitInfo.transform.GetComponent<PickupItem>().item.itemName + " 획득 했습니다.");  // 인벤토리 넣기

                pickUp();
                Destroy(hitInfo.collider.gameObject);//아이템을 삭제한다
                ItemInfoDisappear();
            }
        }
    }
    //줍는 아이템의 정보를 플레이어 인벤토리에 저장
    private void pickUp()
    {
        string itemName = hitInfo.transform.GetComponent<PickupItem>().item.itemName; // 아이템 이름을 저장할 변수
        Item item = hitInfo.transform.GetComponent<PickupItem>().item; // 아이템의 정보를 저장할 변수
        PlayerItem.Instance.inventoryItems.Add(itemName,item); // 배열에 추가하는 정보
    }



}

