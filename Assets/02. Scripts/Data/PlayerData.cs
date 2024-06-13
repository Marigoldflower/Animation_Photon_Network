using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils.Collections;
using UnityEngine;

namespace SCI
{
    [System.Serializable]
    public class PlayerData
    {
        public WeaponData weaponData;
        public SerializableDictionary<CostumeType, int> costumeDatas = new SerializableDictionary<CostumeType, int>();
    }
}