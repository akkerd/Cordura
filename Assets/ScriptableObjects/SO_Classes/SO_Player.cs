using UnityEngine;

[CreateAssetMenu(fileName = "ObjectRef", menuName = "ScriptableObjects/ObjectRef", order = 1)]
public class SO_ObjectRef : ScriptableObject
{
    private GameObject objectRef;

    public GameObject getGameObject()
    {
        return objectRef;
    }

    public void setObjectRef(GameObject pObjectRef)
    {
        this.objectRef = pObjectRef;
    }
}
