using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCI
{
    [System.Serializable]
    public class PlayerData
    {
        // 무기 데이터
        public WeaponData weaponData;
        // 코스튬 데이터
        [SerializeField] private CostumeData[] _costumeDatas;
        public Dictionary<CostumeType, int> costumeDatas = new Dictionary<CostumeType, int>();

        public void Initialize()
        {
            // 초기화 함수 ( DataManager / Awake에서 호출 )
            for (int i = 0; i < _costumeDatas.Length; i++)
            {
                costumeDatas[(CostumeType)i] = _costumeDatas[i].index;
            }
        }
    }
}