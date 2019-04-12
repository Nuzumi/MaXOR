using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaXOR.Services.Tree
{
    public class RootNode : AbstractNode
    {
        private Node child;

        public void Setup(Node child)
        {
            this.child = child;
        }

        public override void SetValue()
        {
            //sprawdz czy wynik sie zgadza
        }
    }
}

