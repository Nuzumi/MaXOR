using System;
using UnityEngine;
using UniRx;
using Maxor.Views;

namespace Maxor.Service
{
    public interface IZoomService
    {
        Action<float> OnZoom { get; set; }
    }

    public class ZoomService : IZoomService
    {
        public Action<float> OnZoom { get; set; }

        private AbstractTreeContainer treeContainer;

        public ZoomService(AbstractTreeContainer treeContainer)
        {
            this.treeContainer = treeContainer;
            var zoomStream = Observable.EveryUpdate()
                .Where(_ => Input.touchCount == 2);

            zoomStream.Subscribe(x => CheckZoom());
        }

        private void CheckZoom()
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);
            if (touch1.phase != TouchPhase.Moved || touch2.phase != TouchPhase.Moved)
                return;

            Vector2 touch1LastPosition = touch1.position - touch1.deltaPosition;
            Vector2 touch2LastPosition = touch2.position - touch2.deltaPosition;
            float positionMagnitude = (touch1.position - touch2.position).magnitude;
            float lastPositionMagnitude = (touch1LastPosition - touch2LastPosition).magnitude;
            OnZoom?.Invoke((positionMagnitude * 100 / lastPositionMagnitude)/100);
        }
    }
}

