using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCI
{
    [System.Serializable]
    public class PlayerData
    {
        // ���� ������
        public WeaponData weaponData;
        // �ڽ�Ƭ ������
        [SerializeField] private CostumeData[] _costumeDatas;
        public Dictionary<CostumeType, int> costumeDatas = new Dictionary<CostumeType, int>();

        public void Initialize()
        {
            // �ʱ�ȭ �Լ� ( DataManager / Awake���� ȣ�� )
            for (int i = 0; i < _costumeDatas.Length; i++)
            {
                costumeDatas[(CostumeType)i] = _costumeDatas[i].index;
            }
        }
    }
}