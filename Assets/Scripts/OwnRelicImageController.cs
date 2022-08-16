﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MRD
{
    public class OwnRelicImageController : MonoBehaviour
    {
        [SerializeField]
        private Transform imageParent;

        public void SetOwnRelicImage()
        {
            var ownRelics = RoundManager.Inst.RelicManager.OwnRelics;

            var transforms = SetRelicsLayers(ownRelics.Count);

            var relicSprites = ResourceDictionary.GetAll<Sprite>("Icons/relics");

            for (int i = 0; i < transforms.Length; i++)
            {
                //이미지 출력
                var images = SetImageLayers(transforms[i], 2);

                if (ownRelics[i].Amount > 1)
                {
                    SetAmountText(transforms[i], ownRelics[i].Amount);
                }

                images[0].sprite = relicSprites[(int)ownRelics[i].Rank];

                //이미지 찾아서 출력하기
                //ScriptableObject 완료까지 보류
                //images[1].sprite = 
            }
        }

        private void SetAmountText(Transform t, int amount)
        {
            //amount >= 10일 때 텍스트 크기 늘리기 (자리수 바뀔 때)
            var amountText = t.GetChild(t.childCount - 1).GetComponent<Text>();
            amountText.gameObject.SetActive(true);
            amountText.text = "X" + amount.ToString();
        }

        private Transform[] SetRelicsLayers(int n)
        {
            var transforms = new Transform[n];

            int childNum = imageParent.childCount;

            var relicsImage = imageParent.GetChild(0);

            for (int i = childNum; i < n; i++) Instantiate(relicsImage, imageParent);

            int newChildNum = imageParent.childCount;

            Transform tmp;
            for (int i = 0; i < n; i++)
            {
                tmp = imageParent.GetChild(i);
                tmp.gameObject.SetActive(true);
                transforms[i] = tmp;
            }

            for (int i = n; i < newChildNum; i++) imageParent.GetChild(i).gameObject.SetActive(false);

            return transforms;
        }

        private Image[] SetImageLayers(Transform t, int n)
        {
            var images = new Image[n];

            int childNum = t.childCount - 1;

            var image = t.GetChild(0);

            var amountText = t.GetChild(childNum);
            amountText.gameObject.SetActive(false);

            for (int i = childNum; i < n; i++) Instantiate(image, t);

            amountText.transform.SetAsLastSibling();

            int newChildNum = t.childCount - 1;

            Transform tmp;
            for (int i = 0; i < n; i++)
            {
                tmp = t.GetChild(i);
                tmp.gameObject.SetActive(true);
                images[i] = tmp.GetComponent<Image>();
                images[i].rectTransform.anchoredPosition = Vector2.zero;
            }

            for (int i = n; i < newChildNum; i++) t.GetChild(i).gameObject.SetActive(false);

            return images;
        }

    }
}

