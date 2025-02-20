namespace Sam.Common.Global.Models;

public class CompositeKey
{
    private const string Delimiter = "|";
    public Guid PersonId { get; set; } = Guid.Empty;
    public Guid ApplicationId { get; set; } = Guid.Empty;
    public int ListId { get; set; } = int.MinValue;
    
    
    //
    //
    // CONSTRUCTORS
    //
    //
    
    
    public CompositeKey() { }

    public CompositeKey(string jsonCompositeKeyToken)
    {
        var key = CompositeKey.StringToCompositeKey(jsonCompositeKeyToken);
        this.ApplicationId = key.ApplicationId;
        this.PersonId = key.PersonId;
        this.ListId = key.ListId;
    }
    
    public CompositeKey(Guid applicationId, Guid personId, int listId)
    {
        this.ApplicationId = applicationId;
        this.PersonId = personId;
        this.ListId = listId;
    }
    
    
    //
    //
    // PUBLIC STATIC HELPER METHODS
    //
    //
    
    
    public static Guid GetApplicationIdFromCompositeId(string compositeId)
    {
        if (string.IsNullOrEmpty(compositeId) || !compositeId.Contains(Delimiter)) return Guid.Empty;
        var appGuidStr = compositeId.Split(Delimiter)[0].Trim();
        return !string.IsNullOrEmpty(appGuidStr) ? StringToGuid(appGuidStr) : Guid.Empty;
    }

    public static Guid GetPersonIdFromCompositeId(string compositeId)
    {
        if (string.IsNullOrEmpty(compositeId) || !compositeId.Contains(Delimiter)) return Guid.Empty;
        var personGuidStr = compositeId.Split(Delimiter)[1].Trim();
        return !string.IsNullOrEmpty(personGuidStr) ? StringToGuid(personGuidStr) : Guid.Empty;
    }
    
    public static int GetListIdFromCompositeId(string compositeId)
    {
        if (string.IsNullOrEmpty(compositeId) || !compositeId.Contains(Delimiter)) return int.MinValue;
        var listIdStr = compositeId.Split(Delimiter)[2].Trim();
        if (string.IsNullOrEmpty(listIdStr)) return int.MinValue;
        return int.TryParse(listIdStr, out var listId) ? listId : int.MinValue;
    }
    
    public static bool IsInList(List<CompositeKey> keys, CompositeKey key)
    {
        var isFound = keys.Any(k =>
            k.ApplicationId == key.ApplicationId 
            && 
            k.PersonId == key.PersonId 
            && 
            k.ListId == key.ListId
        );
        return isFound;
    }

    public static bool IsNotInList(List<CompositeKey> keys, CompositeKey key)
    {
        var isNotFound = !IsInList(keys, key);
        return isNotFound;
    }
        
    public static CompositeKey StringToCompositeKey(string str)
    {
        CompositeKey key = new();
        if (!string.IsNullOrEmpty(str))
        {
            key.ApplicationId = GetApplicationIdFromCompositeId(str);
            key.PersonId = GetPersonIdFromCompositeId(str);
            key.ListId = GetListIdFromCompositeId(str);
        }
        return key;
    }

    public static string OutputCompositeKeyAsString(CompositeKey? key)
    {
        var str = "";
        if (key != null)
        {
            str += key.ApplicationId.ToString() + Delimiter;
            str += key.PersonId.ToString() + Delimiter;
            str += key.ListId.ToString();
        }
        return str;
    }

    public static List<string> ConvertListOfKeysToStringOfKeys(List<CompositeKey?> compositeKeys, bool isUpperCase = false)
    {
        List<string> keyStrings = new();
        if (compositeKeys.Count != 0)
        {
            keyStrings.AddRange(compositeKeys.Select(key => (isUpperCase)
                ? OutputCompositeKeyAsString(key).ToUpper()
                : OutputCompositeKeyAsString(key)));
        }
        return keyStrings;
    }    
    
    public static IEnumerable<CompositeKey> ToCompositeKeys(List<string> compositeKeyStrings)
    {
        return compositeKeyStrings.Select(key => new CompositeKey(key));
    }
    
    public static IEnumerable<CompositeKey> ToCompositeKeys(string jsonKeyListString)
    {
        var compositeKeyStrings = JsonConvert.DeserializeObject<List<string>> (jsonKeyListString);
        if (compositeKeyStrings != null && compositeKeyStrings.Count != 0)
        {
            return ToCompositeKeys(compositeKeyStrings);
        }
        return [];
    }
    
    
    //
    //
    // PRIVATE STATIC HELPER METHODS
    //
    //
    
    
    private static Guid StringToGuid(string guidStr)
    {
        if (string.IsNullOrEmpty(guidStr)) return Guid.Empty;
        return Guid.TryParse(guidStr, out var guid) ? guid : Guid.Empty;
    }
}