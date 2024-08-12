using CarEdit_server.PublicClasses;
using VoltApi.BusinessLogic;

public class DataECU
{
    public string ECU { get; set; }
    public string Id { get; set; }
    public MaskDataCell[] BindingData { get; set; } = Array.Empty<MaskDataCell>();
    public string Length { get; set; }
    public string Message { get; set; }
    public CompositeData DPF { get; set; }
    public CompositeData ADBLUE { get; set; }
    public CompositeData EGR { get; set; }
    public CompositeData IMMO { get; set; }
    public CompositeData SL { get; set; }
    public CompositeData LAMBDA { get; set; }
    public CompositeData AutoRun { get; set; }
    public CompositeData EVAP { get; set; }
    public CompositeData VSA { get; set; }
    public CompositeData TVA { get; set; }
    public CompositeData Crash { get; set; }
    public string VIN { get; set; }
    public string Odometr { get; set; }
    public string PIN { get; set; }
    public ErrorsType ErrorsType { get; set; } = ErrorsType.Default;
    public BitConfig BitConfig { get; set; }
    public bool Clear { get; set; }
    public int ExtraFieldInt1 { get; set; }
    public int ExtraFieldInt2 { get; set; }

    public AdditionalLenghtType AdditionalLenghtType = AdditionalLenghtType.Default;

    public bool CheckDataOnBitMask(int dataIndex, out MaskDataCell errorCell, out byte bitMask)
    {
        errorCell = null;
        bitMask = 0;
        
        if (CheckCompositeData(DPF, out bitMask) ||
            CheckCompositeData(ADBLUE, out bitMask) ||
            CheckCompositeData(EGR, out bitMask) ||
            CheckCompositeData(IMMO, out bitMask) ||
            CheckCompositeData(SL, out bitMask) ||
            CheckCompositeData(LAMBDA, out bitMask) ||
            CheckCompositeData(AutoRun, out bitMask) ||
            CheckCompositeData(EVAP, out bitMask) ||
            CheckCompositeData(VSA, out bitMask) ||
            CheckCompositeData(TVA, out bitMask))
        {
            errorCell = BindingData[dataIndex];
            return true;
        }

        return false;

        bool CheckCompositeData(CompositeData compositeData, out byte mask)
        {
            mask = 0;
            if (compositeData is { BitOffsetErrors.Length: > 0 } && dataIndex < compositeData.BitOffsetErrors.Length)
            {
                if (compositeData.Errors.Length != compositeData.BitOffsetErrors.Length)
                {
                    throw new Exception();
                }
                for (var i = 0; i < compositeData.Errors.Length; i++)
                {
                    if (compositeData.Errors[i] == BindingData[dataIndex].ErrorCode)
                    {
                        mask = compositeData.BitOffsetErrors[i];
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

public enum AdditionalLenghtType
{
    Default,
    Lenght9,
    Lenght10,
    Lenght12,
    Lenght14,
}

public enum EcuDataType
{
    Normal,
    Vin,
    Odometr
}