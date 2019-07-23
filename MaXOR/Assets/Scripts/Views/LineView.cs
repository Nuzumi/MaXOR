using Maxor.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Maxor.Views
{
    public interface ILineView
    {
        void SetPositions(Vector3 position1, Vector3 position2);
    }

    [Prefab("Assets/GFX/Lines/LineView")]
    public class LineView : MonoBehaviour, ILineView
    {
        public Image horizontalImage;
        public Image verticalImage;

        public void SetPositions(Vector3 position1,Vector3 position2)
        {
            if (position1.x == position2.x)
            {
                horizontalImage.gameObject.SetActive(false);
                SetVerticalImageAsOnly(position1, position2);
                return;
            }
            
            SetHorizontalImage(Vector3.zero, position1);
            SetVerticalImage(Vector3.zero, position1);
            
        }

        private void SetVerticalImageAsOnly(Vector3 position1, Vector3 position2)
        {
            verticalImage.rectTransform.sizeDelta = new Vector2(verticalImage.rectTransform.rect.size.x,(position1 - position2).magnitude );
            verticalImage.rectTransform.anchoredPosition = new Vector2(position1.x, Mathf.Min(position1.y, position2.y) + Mathf.Abs(position1.y - position2.y) / 2);
            verticalImage.gameObject.SetActive(true);
        }

        private void SetVerticalImage(Vector3 position1, Vector3 position2)
        {
            verticalImage.rectTransform.sizeDelta = new Vector2(verticalImage.rectTransform.rect.size.x,Math.Abs(position2.y) + verticalImage.rectTransform.rect.size.x);
            verticalImage.rectTransform.anchoredPosition = new Vector2(position2.x, position1.y + position2.y / 2);
            verticalImage.gameObject.SetActive(true);
        }

        private void SetHorizontalImage(Vector3 position1, Vector3 position2)
        {
            horizontalImage.rectTransform.sizeDelta = new Vector2(Mathf.Abs(position2.x) + horizontalImage.rectTransform.rect.size.y, horizontalImage.rectTransform.rect.size.y);
            horizontalImage.rectTransform.anchoredPosition = new Vector2(position1.x + position2.x / 2, position1.x);
            horizontalImage.gameObject.SetActive(true);
        }
    }
}

