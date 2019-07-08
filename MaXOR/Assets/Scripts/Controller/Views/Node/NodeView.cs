using System.Collections;
using System.Collections.Generic;
using Maxor.Views;
using UnityEngine;

namespace Maxor.Model.View
{
    public interface INodeView : IView
    {

    }

    public class NodeView : View<NodeViewComponent>, INodeView
    {
        public NodeView(IServices services, IViews views) : base(services, views)
        {

        }
    }
}

