using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New string",menuName = "Loc. String")]
public class LocalizableString : ScriptableObject
{
    public string spanish;
    public string english;

    public string GetString(Language language)
    {
        switch (language)
        {
            case Language.Spanish:
                return spanish;
            case Language.English:
                return english;
        }

        return null;
    }

    [System.Serializable]
    public enum Language { English,Spanish};
}
