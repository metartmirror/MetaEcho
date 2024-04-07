using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Game Mode", menuName = "General/GameMode", order = 1)]
public class GameMode : ScriptableObject
{
    [Title("Basic Information")]
    [SerializeField, LabelText("Name")]
    private string modeName = "New GameMode";
    
    [SerializeField]
    private int modeID = 0;

    [PreviewField(150,ObjectFieldAlignment.Left)]
    [SerializeField]
    private Sprite picture;
    
    [TextArea(5, 25)]
    public string description;

    // Public properties to access private fields
    public string ClassName
    {
        get => modeName;
        set => modeName = value;
    }
    
    public int ClassID
    {
        get => modeID;
        set => modeID = value;
    }


    public Sprite Icon
    {
        get => picture;
        set => picture = value;
    }
    
#if UNITY_EDITOR
    [Button("Rename")]
    private void Rename()
    {
        if (modeName == string.Empty)return;
        var thisFileNewName = modeID + "-" + modeName;
        var assetPath = UnityEditor.AssetDatabase.GetAssetPath(this.GetInstanceID());
        UnityEditor.AssetDatabase.RenameAsset(assetPath, thisFileNewName);
    }
#endif
}
