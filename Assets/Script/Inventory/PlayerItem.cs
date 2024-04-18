using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    public static PlayerItem Instance { get; private set; }   // PlayerItem�� �̱��� �ν��Ͻ�

    [Header("Player Inventory")]
    public Dictionary<string, Item> inventoryItems;   // �κ��丮 �� ������ ���

    private void Awake()
    {
        inventoryItems = new Dictionary<string, Item>();

        // �̱��� �ν��Ͻ��� �����մϴ�.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ���� �ٲ� ������Ʈ�� �ı����� �ʵ��� �մϴ�.
        }
        else
        {
            Destroy(gameObject); // �̹� �ν��Ͻ��� �����ϴ� ��� ���� ������Ʈ�� �ı��մϴ�.
        }
    }
}


