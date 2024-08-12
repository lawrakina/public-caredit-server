using CarEdit_server.PublicClasses;

namespace CarEdit_server.Extentions
{
    internal static class ListExtentions
    {
        public static List<MaskDataCell> SortBindingData(List<MaskDataCell> bindingData)
        {
            var removedList = new List<MaskDataCell>();
            for (int i = 0; i < bindingData.Count; i++)
            {
                if (bindingData[i].ErrorCode == 0)
                    removedList.Add(bindingData[i]);
            }
            foreach (var data in removedList)
            {
                bindingData.Remove(data);
            }

            bindingData.Sort((a, b) => a.ErrorCode.CompareTo(b.ErrorCode));

            var listLetters = new List<MaskDataCell>();
            var listNumbers = new List<MaskDataCell>();

            foreach (var data in bindingData)
            {
                if (data.ErrorCode > 0)
                    listNumbers.Add(data);
                else
                    listLetters.Add(data);
            }

            bindingData = listNumbers;
            bindingData.AddRange(listLetters);

            return bindingData;
        }
    }
}