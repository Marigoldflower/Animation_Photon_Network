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
            // 코스튬 정보 초기화 작업
            for (int i = 0; i < Enum.GetValues(typeof(CostumeType)).Length; i++)
            {
                // enum타입을 순회하여 각 타입별로 원소를 추가
                var type = (CostumeType)Enum.ToObject(typeof(CostumeType), i);
                playerData.costumeDatas.Add(type, 0);
            }
        }

        public int GetCostumeData(CostumeType type)
        {
            // 현재 코스튬을 가져오기
            return playerData.costumeDatas[type];
        }

        public void SetCostumeData(CostumeData data)
        {
            // 코스튬을 세팅하기
            playerData.costumeDatas[data.type] = data.index;
        }
        #endregion
    }
}