using Maxor.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maxor.Service
{
    public interface ILineRendererCreatorService
    {
        ILineView CreateLine(Vector3 position1, Vector3 position2, Transform parent);
    }

    public class LineRendererCreatorService : ILineRendererCreatorService
    {
        private Transform canvas;
        private IServices services;

        public LineRendererCreatorService(IServices services,Transform canvas)
        {
            this.services = services;
            this.canvas = canvas;
        }

        public ILineView CreateLine(Vector3 position1, Vector3 position2, Transform parent)
        {

            LineView lineView = services.PrefabsService.Get<LineView, LineView>(parent);
            lineView.SetPositions(position1,position2);
            lineView.transform.SetAsFirstSibling();

            return lineView;
        }
    }
}

