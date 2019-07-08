using Maxor.Service;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using Maxor.Utils;

namespace Maxor.Views
{
    public interface IInputNumber
    {
        int Value { get; }

        void Init(Transform canvas, IInputNumberDropService numberDropService, int value);
        void Release();
        void Hide();
    }

    [PrefabAttribute("Assets/GFX/Views/InputNumber")]
    public class InputNumber : MonoBehaviour, IInputNumber
    {
        public TextMeshProUGUI valueText;

        private Transform parent;
        private Transform canvas;
        private IInputNumberDropService numberDropService;

        public int Value { get; private set; }

        public void Init(Transform canvas, IInputNumberDropService numberDropService, int value)
        {
            this.canvas = canvas;
            this.numberDropService = numberDropService;
            Value = value;
            parent = transform.parent;
            valueText.text = Value.ToString();
        }

        public void OnDragBegin()
        {
            transform.SetParent(canvas);
        }

        public void OnDrag()
        {
            transform.position = Input.mousePosition;
        }

        public void OnDragEnd()
        {
            bool result = numberDropService.Drop(transform.position, this);
            if (!result)
                Release();
        }

        public void Release()
        {
            transform.SetParent(parent);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
