using System.Collections.Generic;
using Malee.List;
using UnityEngine;

namespace Map
{
    [CreateAssetMenu]
    public class MapConfig : ScriptableObject
    {
        public List<NodeBlueprint> nodeBlueprints;
        public int GridWidth => Mathf.Max(numOfPreBossNodes.max, numOfStartingNodes.max);

        public int MinPreBossNodes;
        public int MaxPreBossNodes;
        public int MinStartingNodes;
        public int MaxStartingNodes;

        [Tooltip("Increase this number to generate more paths")]
        public int extraPaths;
        [Reorderable]
        public ListOfMapLayers layers;

        [System.Serializable]
        public class ListOfMapLayers : ReorderableArray<MapLayer>
        {
        }

        [HideInInspector]
        public IntMinMax numOfPreBossNodes => new IntMinMax(MinPreBossNodes, MaxPreBossNodes);
        [HideInInspector]
        public IntMinMax numOfStartingNodes => new IntMinMax(MinStartingNodes, MaxStartingNodes);
    }
}
