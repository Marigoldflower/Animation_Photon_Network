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
        public Dictionary<CostumeType, int> costumeDatas = new Dictionary<CostumeType, int>();
    }
}