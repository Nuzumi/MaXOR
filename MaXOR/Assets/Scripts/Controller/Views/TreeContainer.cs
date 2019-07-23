using Maxor.Model;
using Maxor.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Maxor.Views
{
    public abstract class AbstractTreeContainer : MonoBehaviour
    {
        public abstract void SetContainerSize(NodeContainer nodeContainer);
        public abstract void Init(IZoomService zoomService);
    }

    public class TreeContainer : AbstractTreeContainer
    {
        [Range(1,5)]
        public float marginMultiplier = 3;
        public RectTransform rectTransform;

        public override void Init(IZoomService zoomService)
        {
            zoomService.OnZoom += Zoom;
        }

        public override void SetContainerSize(NodeContainer nodeContainer)
        {
            List<Vector2> positions = new List<Vector2>();
            nodeContainer.GetPositions(positions);
            float minY = positions.Select(v => v.y).Min();
            var xPositions = positions.Select(v => v.x);
            float minX = xPositions.Min();
            float maxX = xPositions.Max();
            rectTransform.sizeDelta = new Vector2(maxX - minX, -minY);
            nodeContainer.RectTransform.anchoredPosition = new Vector2(-((maxX - minX)/2 + minX), -minY / 2);
            rectTransform.sizeDelta += new Vector2(StaticConstants.nodeSize * marginMultiplier, StaticConstants.nodeSize * marginMultiplier);
        }

        private void Zoom(float touchDelta)
        {
            Debug.Log(touchDelta);
            rectTransform.localScale = new Vector3(rectTransform.localScale.x * touchDelta, rectTransform.localScale.y * touchDelta, 1);
        }
    }
}

