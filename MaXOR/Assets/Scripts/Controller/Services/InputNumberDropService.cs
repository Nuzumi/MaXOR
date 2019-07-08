using Maxor.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maxor.Service
{
    public interface IInputNumberDropService
    {
        void Addtarget(Transform targetTransform, IDropable container);
        bool Drop(Vector3 position, IInputNumber inputNumber);
    }

    public class InputNumberDropService : IInputNumberDropService
    {
        private List<Transform> targetTransforms;
        private Dictionary<Transform, IDropable> nodeContainers;
        private float sqrOffsetDistance = 2500;

        public InputNumberDropService()
        {
            targetTransforms = new List<Transform>();
            nodeContainers = new Dictionary<Transform, IDropable>();
        }

        public void Addtarget(Transform targetTransform, IDropable container)
        {
            targetTransforms.Add(targetTransform);
            nodeContainers.Add(targetTransform, container);
        }

        public bool Drop(Vector3 position, IInputNumber inputNumber)
        {
            IDropable target = GetDropTarget(position);

            if (target == null)
                return false;

            target.Drop(inputNumber);
            return true;
        }

        private IDropable GetDropTarget(Vector3 position)
        {
            for (int i = 0; i < targetTransforms.Count; i++)
                if ((position - targetTransforms[i].position).sqrMagnitude < 2500)
                    return nodeContainers[targetTransforms[i]];

            return null;
        }
    }
}

