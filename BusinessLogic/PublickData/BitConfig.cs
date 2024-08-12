public class BitConfig
{
    public long Address { get; }
    public int Length { get; }
    public bool[] BitArray { get; set; }
    public bool DirectionForward { get; }

    public long DPF { get; set; } = -1;
    public long ADBLUE { get; set; } = -1;
    public long EGR { get; set; } = -1;
    public long IMMO { get; set; } = -1;
    public long SL { get; set; } = -1;
    public long LAMBDA { get; set; } = -1;
    public long AutoRun { get; set; } = -1;
    public long EVAP { get; set; } = -1;
    public long VSA { get; set; } = -1;
    public long TVA { get; set; } = -1;

    public BitConfig(long address, int length, bool[] bitArray, bool directionForward)
    {
        Address = address;
        Length = length;
        BitArray = bitArray;
        DirectionForward = directionForward;
    }
}