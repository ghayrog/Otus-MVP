using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    [Serializable]
    public sealed class StackPanel
    {
        [SerializeField]
        private StackPanelElement _stackElementPrefab;

        [SerializeField]
        private Transform _parentScrollViewContent;

        private List<StackPanelElement> _stackPanelElements = new List<StackPanelElement>();

        public StackPanelElement AddStackElement(string description, string value)
        {
            var stackPanelElement = GameObject.Instantiate(_stackElementPrefab, _parentScrollViewContent);
            stackPanelElement.SetDescription(description);
            stackPanelElement.SetValue(value);
            _stackPanelElements.Add(stackPanelElement);
            return stackPanelElement;
        }

        public void RemoveStackElement(StackPanelElement element)
        {
            if (_stackPanelElements.Contains(element))
            {
                _stackPanelElements.Remove(element);
                GameObject.Destroy(element);
            }

        }

        public void ClearStackPanel()
        {
            while (_stackPanelElements.Count > 0)
            {
                var element = _stackPanelElements[0];
                _stackPanelElements.RemoveAt(0);
                GameObject.Destroy(element);
            }
        }
    }
}