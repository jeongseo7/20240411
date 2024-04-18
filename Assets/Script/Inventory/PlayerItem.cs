using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    public static PlayerItem Instance { get; private set; }   // PlayerItem의 싱글톤 인스턴스

    [Header("Player Inventory")]
    public Dictionary<string, Item> inventoryItems;   // 인벤토리 내 아이템 목록

    private void Awake()
    {
        inventoryItems = new Dictionary<string, Item>();

        // 싱글톤 인스턴스를 설정합니다.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 오브젝트가 파괴되지 않도록 합니다.
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 존재하는 경우 현재 오브젝트를 파괴합니다.
        }
    }
}


