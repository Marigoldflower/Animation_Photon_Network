using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCI
{
    public class CharacterAvatar : MonoBehaviour
    {
        // 스킨 목록
        public Transform headTf;
        public Transform faceTf;
        public Transform upperTf;
        public Transform lowerTf;
        public Transform footTf;

        private GameObject currentHead;
        private GameObject currentFace;
        private GameObject currentUpper;
        private GameObject currentLower;
        private GameObject currentFoot;

        public void Initialize()
        {
            // 초기화 작업
            for (int i = 0; i < Enum.GetValues(typeof(CostumeType)).Length; i++)
            {
                // enum타입을 순회하여 각 타입별로 코스튬 착용
                var type = (CostumeType)Enum.ToObject(typeof(CostumeType), i);
                SwitchCostume(type);
            }
        }

        public void SwitchCostume(CostumeType type)
        {
            // 코스튬 변경
            switch (type)
            {
                case CostumeType.Head:
                    UnDressCostume(CostumeType.Head);
                    DressCostume(CostumeType.Head);
                    break;
                case CostumeType.Face:
                    UnDressCostume(CostumeType.Face);
                    DressCostume(CostumeType.Face);
                    break;
                case CostumeType.Upper:
                    UnDressCostume(CostumeType.Upper);
                    DressCostume(CostumeType.Upper);
                    break;
                case CostumeType.Lower:
                    UnDressCostume(CostumeType.Lower);
                    DressCostume(CostumeType.Lower);
                    break;
                case CostumeType.Foot:
                    UnDressCostume(CostumeType.Foot);
                    DressCostume(CostumeType.Foot);
                    break;
            }
        }

        private void DressCostume(CostumeType type)
        {
            var instance = DataManager.Instance;

            // 코스튬 장착
            switch (type)
            {
                // ~Tf의 자식오브젝트 갯수가 데이터 값보다 높을 때만 실행 (인덱스 오류 방지)
                case CostumeType.Head:
                    if (headTf.childCount > instance.GetCostumeData(CostumeType.Head))
                    {
                        currentHead = headTf.GetChild(instance.GetCostumeData(CostumeType.Head)).gameObject;
                        currentHead.SetActive(true);
                    }
                    break;
                case CostumeType.Face:
                    if (faceTf.childCount > instance.GetCostumeData(CostumeType.Face))
                    {
                        currentFace = faceTf.GetChild(instance.GetCostumeData(CostumeType.Face)).gameObject;
                        currentFace.SetActive(true);
                    }
                    break;
                case CostumeType.Upper:
                    if (upperTf.childCount > instance.GetCostumeData(CostumeType.Upper))
                    {
                        currentUpper = upperTf.GetChild(instance.GetCostumeData(CostumeType.Upper)).gameObject;
                        currentUpper.SetActive(true);
                    }
                    break;
                case CostumeType.Lower:
                    if (lowerTf.childCount > instance.GetCostumeData(CostumeType.Lower))
                    {
                        currentLower = lowerTf.GetChild(instance.GetCostumeData(CostumeType.Lower)).gameObject;
                        currentLower.SetActive(true);
                    }
                    break;
                case CostumeType.Foot:
                    if (footTf.childCount > instance.GetCostumeData(CostumeType.Foot))
                    {
                        currentFoot = footTf.GetChild(instance.GetCostumeData(CostumeType.Foot)).gameObject;
                        currentFoot.SetActive(true);
                    }
                    break;
            }
        }

        private void UnDressCostume(CostumeType type)
        {
            Transform parentTf = null;

            switch (type)
            {
                case CostumeType.Head:
                    if (currentHead != null)
                    {
                        parentTf = headTf;
                    }
                    break;
                case CostumeType.Face:
                    if (currentHead != null)
                    {
                        parentTf = faceTf;
                    }
                    break;
                case CostumeType.Upper:
                    if (currentHead != null)
                    {
                        parentTf = upperTf;
                    }
                    break;
                case CostumeType.Lower:
                    if (currentHead != null)
                    {
                        parentTf = lowerTf;
                    }
                    break;
                case CostumeType.Foot:
                    if (currentHead != null)
                    {
                        parentTf = footTf;
                    }
                    break;
            }

            // 코스튬 해제
            if (parentTf != null)
            {
                for (int i = 0; i < parentTf.childCount; i++)
                {
                    parentTf.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }
}