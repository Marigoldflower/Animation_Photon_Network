using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SCI
{
    public class DataManager : MonoBehaviour
    {
        #region Singleton
        private static DataManager instance;
        public static DataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    var obj = FindObjectOfType<DataManager>();

                    if (obj != null)
                    {
                        instance = obj;
                    }
                    else
                    {
                        var newObj = new GameObject();
                        newObj.AddComponent<DataManager>();

                        instance = newObj.GetComponent<DataManager>();
                    }
                }

                return instance;
            }
        }
        #endregion

        [SerializeField] private PlayerData playerData;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;

                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }

            playerData.Initialize();
        }

        #region Methods
        public WeaponData GetWeaponData()
        {
            return playerData.weaponData;
        }

        public void SetWeaponData(WeaponData newData)
        {
            playerData.weaponData = newData;
        }

        public Dictionary<CostumeType, int> GetCostumeDatas()
        {
            return playerData.costumeDatas;
        }

        public int GetCostumeData(CostumeType type)
        {
            // ���� �ڽ�Ƭ������ ��������
            return playerData.costumeDatas[type];
        }

        public void SetCostumeData(CostumeData newData)
        {
            // �ڽ�Ƭ�� �����ϱ�
            playerData.costumeDatas[newData.type] = newData.index;
        }
        #endregion
    }
}