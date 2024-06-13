using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCI
{
    public enum WeaponType
    {
        None,
        ShortSword,
        DualSword,
        GreatSword
    }

    [System.Serializable]
    public class WeaponData
    {
        public WeaponType type;
        public int index;
    }
}