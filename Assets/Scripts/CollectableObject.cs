using UnityEngine;

[CreateAssetMenu(menuName = "CollectableType")]
public class CollectableObject : ScriptableObject
{
   [SerializeField]private CollectableEnum _type;
   [SerializeField]private GameObject _typePrefab;
}