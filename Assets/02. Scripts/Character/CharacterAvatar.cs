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

        public int currentHead { get; private set; }
        public int currentFace { get; private set; }
        public int currentUpper { get; private set; }
        public int currentLower { get; private set; }
        public int currentFoot { get; private set; }

        public void Initialize()
        {
            // 초기화 작업
            for (int i = 0; i < Enum.GetValues(typeof(CostumeType)).Length; i++)
            {
                // enum타입을 순회하여 각 타입별로 코스튬 착용
                var type = (CostumeType)Enum.ToObject(typeof(CostumeType), i);
                SetCostume(type, DataManager.Instance.GetCostumeData(type));
            }
        }

        public void SetCostume(CostumeType type, int index)
        {
            // 코스튬 변경
            switch (type)
            {
                case CostumeType.Head:
                    UnDressCostume(CostumeType.Head);
                    DressCostume(CostumeType.Head, index);
                    break;
                case CostumeType.Face:
                    UnDressCostume(CostumeType.Face);
                    DressCostume(CostumeType.Face, index);
                    break;
                case CostumeType.Upper:
                    UnDressCostume(CostumeType.Upper);
                    DressCostume(CostumeType.Upper, index);
                    break;
                case CostumeType.Lower:
                    UnDressCostume(CostumeType.Lower);
                    DressCostume(CostumeType.Lower, index);
                    break;
                case CostumeType.Foot:
                    UnDressCostume(CostumeType.Foot);
                    DressCostume(CostumeType.Foot, index);
                    break;
            }
        }

        private void DressCostume(CostumeType type, int index)
        {
            var instance = DataManager.Instance;

            // 코스튬 장착
            switch (type)
            {
                // ~Tf의 자식오브젝트 갯수가 데이터 값보다 높을 때만 실행 (인덱스 오류 방지)
                case CostumeType.Head:
                    if (headTf.childCount > instance.GetCostumeData(CostumeType.Head))
                    {
                        currentHead = index;
                        headTf.GetChild(index).gameObject.SetActive(true);
                    }
                    break;
                case CostumeType.Face:
                    if (faceTf.childCount > instance.GetCostumeData(CostumeType.Face))
                    {
                        currentFace = index;
                        faceTf.GetChild(index).gameObject.SetActive(true);
                    }
                    break;
                case CostumeType.Upper:
                    if (upperTf.childCount > instance.GetCostumeData(CostumeType.Upper))
                    {
                        currentUpper = index;
                        upperTf.GetChild(index).gameObject.SetActive(true);
                    }
                    break;
                case CostumeType.Lower:
                    if (lowerTf.childCount > instance.GetCostumeData(CostumeType.Lower))
                    {
                        currentLower = index;
                        lowerTf.GetChild(index).gameObject.SetActive(true);
                    }
                    break;
                case CostumeType.Foot:
                    if (footTf.childCount > instance.GetCostumeData(CostumeType.Foot))
                    {
                        currentFoot = index;
                        footTf.GetChild(index).gameObject.SetActive(true);
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