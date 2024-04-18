using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu] (filename, menuName, order)
// filename 이 에셋을 생성하게 되면 기본적으로 지어질 이름
// menuName 유니티 에셋-우클-Create- 메뉴에 보일 이름
// order 메뉴에 보일 순서 (기본적으론 첫 번째)

[CreateAssetMenu(fileName =" New Item", menuName = "New Item/item")]
//ScriptableObject는 사본 생성 방지/ 프리팹이 있으면 유용함
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Equipment,
        Used,
        Ingredient,
        ETC,
    }

    public string itemName; //이름
    public ItemType itemtype; // 타입
    //Sprite는 월드 어디서든 이미지를 띄울 수 있다.
    public Sprite itemImage;// 인벤에 띄을 이미지
    public GameObject itemPrefab;// 아이템 프리팹(아이템 생성시 프리팹으로 찍어냄)

    public string WeaponType;
}
