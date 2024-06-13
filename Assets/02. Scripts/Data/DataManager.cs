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

        public PlayerData playerData = new PlayerData();
        private CharacterAvatar characterAvatar;

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

            Initialize();
        }

        #region Methods
        public void Initialize()
        {
            // �ڽ�Ƭ ���� �ʱ�ȭ �۾�
            for (int i = 0; i < Enum.GetValues(typeof(CostumeType)).Length; i++)
            {
                // enumŸ���� ��ȸ�Ͽ� �� Ÿ�Ժ��� ���Ҹ� �߰�
                var type = (CostumeType)Enum.ToObject(typeof(CostumeType), i);
                playerData.costumeDatas.Add(type, 0);
            }
        }

        public int GetCostumeData(CostumeType type)
        {
            // ���� �ڽ�Ƭ�� ��������
            return playerData.costumeDatas[type];
        }

        public void SetCostumeData(CostumeData data)
        {
            // �ڽ�Ƭ�� �����ϱ�
            playerData.costumeDatas[data.type] = data.index;
        }
        #endregion
    }
}