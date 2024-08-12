using Newtonsoft.Json;

[Serializable]
public class CompositeData
{
    private bool _value;
    private UInt32[] _errors;
    private bool allErrors;

    public bool Value
    {
        get => _value;
        set => this._value = value;
    }

    public UInt32[] Errors
    {
        get => _errors;
        set => _errors = value;
    }

    public bool AllErrors { 
        get => allErrors; 
        set => allErrors = value; 
    }
    
    //требуется в случаях когда value хранится не в байтах, а в бите
    public byte[] BitOffsetErrors { get; set; }

    [JsonConstructor]
    public CompositeData(bool value, UInt32[] errors, bool allErrors = false, byte[] offsetErrors = null)
    {
        Value = value;
        Errors = errors != null ? errors : new UInt32[0];
        AllErrors = allErrors;
        BitOffsetErrors = offsetErrors;
    }

    internal void SetValue(bool value)
    {
        _value = value;
    }
}