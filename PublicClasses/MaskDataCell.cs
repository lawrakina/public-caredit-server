namespace CarEdit_server.PublicClasses
{
    [Serializable]
    public class MaskDataCell
    {
        public long Adress;
        public List<long> ExtraAdresses;

        public List<DependentError> DependentErrors { get; set; }

        public int Data;
        public ushort ErrorCode;
        public List<ushort> ExtraErrors;
        private bool _selected;
        public MaskDataCellType MaskType { get; set; }
        public byte ErrorCodeSuffix;
        public string Message;
        public MaskDataCellClearType ClearType;


        public MaskDataCell()
        {
            
        }

        public MaskDataCell(long adress, int data, MaskDataCellType maskType = MaskDataCellType.Default)
        {
            Adress = adress;
            Data = data;
            MaskType = maskType;

            ExtraErrors = new List<ushort>();
            ExtraAdresses = new List<long>();

            DependentErrors = new List<DependentError>();
        }

        public bool Selected
        {
            get => _selected;
            set => _selected = value;
        }
        public NumberSystem ErrorNumberSystem { get; set; } = NumberSystem.Hexadecimal;

        internal void ClearData()
        {
            ClearType = MaskDataCellClearType.All;
            Data = 0x000;
        }

        public void ClearBitDataWithOffset(byte bitOffset)
        {
            ClearType = MaskDataCellClearType.OnlyBit;
            Data &= ~(1 << bitOffset);
        }

        internal void AddDependent(long adress, DependentErrorType dependentErrorType)
        {
            DependentErrors.Add(new DependentError() { address = adress, DependentErrorType = dependentErrorType});
        }

        internal void AddRangeDependent(List<DependentError> dependentErrorrs)
        {
            DependentErrors.AddRange(dependentErrorrs);
        }
    }

    public class DependentError
    {
        public long address { get; set; }
        public DependentErrorType DependentErrorType { get; set; }
    }

    public enum DependentErrorType
    {
        x00,
        x0000,
        x00000000,
        x0000000000000000,
        x00000000000000000000,
        xFF,
        xFFFF,
        xFFFFFFFF,
        xFFFFFFFFFFFFFFFF,
    }

    public enum MaskDataCellType
    {
        Default,
        Renault_before10,
    }
    
    public enum MaskDataCellClearType
    {
        All,
        OnlyBit
    }

    public enum NumberSystem
    {
        Hexadecimal,
        Decimal,
    }
}
