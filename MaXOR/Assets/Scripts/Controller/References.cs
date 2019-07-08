﻿using Maxor.Utils;
using UnityEngine;

namespace Maxor
{
    public interface IReferences
    {
        IPrefabsReferences PrefabsReferences { get; }
        ISpriteReferences SpriteReferences { get; }
        IWorldReferences WorldReferences { get; }
    }

    public class References : MonoBehaviour, IReferences
    {
        public IPrefabsReferences PrefabsReferences => prefabsReferences;
        public PrefabsReferences prefabsReferences;

        public ISpriteReferences SpriteReferences => SpriteReferences;
        public SpriteReferences spriteReferences;

        public IWorldReferences WorldReferences => worldReferences;
        public WorldReferences worldReferences;
    }
}