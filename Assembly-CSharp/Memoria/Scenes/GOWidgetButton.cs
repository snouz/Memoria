using UnityEngine;

namespace Memoria.Scenes
{
    internal class GOWidgetButton : GOWidget
    {
        public readonly UIButton Button;
        public readonly BoxCollider BoxCollider;

        public UIEventListener EventListener => UIEventListener.Get(GameObject);

        public GOWidgetButton(GameObject obj)
            : base(obj)
        {
            Button = obj.GetExactComponent<UIButton>();
            BoxCollider = obj.GetExactComponent<BoxCollider>();
        }
    }
}
