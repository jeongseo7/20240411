using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    //얻은 아이템
    public Item item;
    //얻은 아이템의 수
    public int itemCount;
    //아이템의 이미지
    public Image itemImage;

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

    //아이템 이미지의 투명도 조절
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    //인벤토리에 새로운 아이템 슬롯 추가
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        //만약 아이템이 무기/장비가 아니라면
        if (item.itemtype != Item.ItemType.Equipment)
        {
            go_CountImage.SetActive(true); // 숫자UI 활성화
            text_Count.text = itemCount.ToString(); // 숫자 텍스트 활성화
        }
        else //장비라면 
        {   
            text_Count.text = "0";// 숫자 텍스트는 0
            go_CountImage.SetActive(false);// 숫자 UI 비활성화
        }
        SetColor(1);//투명도를 낮춰서 아이템 이미지 
    }
    //해당 슬롯의 아이템 갯수 업데이트
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();// 텍스트 업데이트

        if(itemCount <= 0)
        {
            ClearSlot();
        }
    }

    //해당 슬롯 하나 삭제
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }

}
