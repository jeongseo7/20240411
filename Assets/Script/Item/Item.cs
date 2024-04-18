using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu] (filename, menuName, order)
// filename �� ������ �����ϰ� �Ǹ� �⺻������ ������ �̸�
// menuName ����Ƽ ����-��Ŭ-Create- �޴��� ���� �̸�
// order �޴��� ���� ���� (�⺻������ ù ��°)

[CreateAssetMenu(fileName =" New Item", menuName = "New Item/item")]
//ScriptableObject�� �纻 ���� ����/ �������� ������ ������
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Equipment,
        Used,
        Ingredient,
        ETC,
    }

    public string itemName; //�̸�
    public ItemType itemtype; // Ÿ��
    //Sprite�� ���� ��𼭵� �̹����� ��� �� �ִ�.
    public Sprite itemImage;// �κ��� ���� �̹���
    public GameObject itemPrefab;// ������ ������(������ ������ ���������� ��)

    public string WeaponType;
}
