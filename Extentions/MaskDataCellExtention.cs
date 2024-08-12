using CarEdit_server.PublicClasses;

namespace CarEdit_Server.Extentions
{
    public static partial class MaskDataCellExtention
    {
        public static void AddRangeDepend(this MaskDataCell cell, List<DependentError> errors, int offset)
        {
            if (errors.Count > 0)
            {
                var tempList = new List<DependentError>();
                foreach (var dependentError in errors)
                {
                    switch (dependentError.DependentErrorType)
                    {
                        case DependentErrorType.xFF:
                            tempList.Add(new DependentError() { address = dependentError.address + offset, DependentErrorType = dependentError.DependentErrorType });
                            break;
                        case DependentErrorType.xFFFF:
                            tempList.Add(new DependentError() { address = dependentError.address + offset * 2, DependentErrorType = dependentError.DependentErrorType });
                            break;
                        case DependentErrorType.xFFFFFFFF:
                            tempList.Add(new DependentError() { address = dependentError.address + offset * 4, DependentErrorType = dependentError.DependentErrorType });
                            break;
                        case DependentErrorType.xFFFFFFFFFFFFFFFF:
                            tempList.Add(new DependentError() { address = dependentError.address + offset * 8, DependentErrorType = dependentError.DependentErrorType });
                            break;

                        case DependentErrorType.x00:
                            tempList.Add(new DependentError() { address = dependentError.address + offset , DependentErrorType = dependentError.DependentErrorType });
                            break;
                        case DependentErrorType.x0000:
                            tempList.Add(new DependentError() { address = dependentError.address + offset * 2, DependentErrorType = dependentError.DependentErrorType });
                            break;
                        case DependentErrorType.x00000000:
                            tempList.Add(new DependentError() { address = dependentError.address + offset * 4, DependentErrorType = dependentError.DependentErrorType });
                            break;
                        case DependentErrorType.x0000000000000000:
                            tempList.Add(new DependentError() { address = dependentError.address + offset * 8, DependentErrorType = dependentError.DependentErrorType });
                            break;
                        case DependentErrorType.x00000000000000000000:
                            tempList.Add(new DependentError() { address = dependentError.address + offset * 10, DependentErrorType = dependentError.DependentErrorType });
                            break;
                    }
                }

                cell.AddRangeDependent(tempList);
            }
        }
    }
}
