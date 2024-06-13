using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCI
{
    public class CharacterAvatar : MonoBehaviour
    {
        // ��Ų ���
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
            // �ʱ�ȭ �۾�
            for (int i = 0; i < Enum.GetValues(typeof(CostumeType)).Length; i++)
            {
                // enumŸ���� ��ȸ�Ͽ� �� Ÿ�Ժ��� �ڽ�Ƭ ����
                var type = (CostumeType)Enum.ToObject(typeof(CostumeType), i);
                SetCostume(type, DataManager.Instance.GetCostumeData(type));
            }
        }

        public void SetCostume(CostumeType type, int index)
        {
            // �ڽ�Ƭ ����
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

            // �ڽ�Ƭ ����
            switch (type)
            {
                // ~Tf�� �ڽĿ�����Ʈ ������ ������ ������ ���� ���� ���� (�ε��� ���� ����)
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

            // �ڽ�Ƭ ����
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