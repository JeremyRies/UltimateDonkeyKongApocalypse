using UnityEngine;

[CreateAssetMenu(menuName = "CollectableType")]
public class CollectableObject : ScriptableObject
{
   [SerializeField]public CollectableEnum Type;
   [SerializeField] public Sprite Icon;
   [SerializeField]public GameObject Prefab;
}