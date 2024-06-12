using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CI.QuickSave;

namespace Save
{
    public enum DataType /*After adding element to this enum, update GetDataName*/
    {
        Colletion,
        Deck
    }

    public class SaveSystem
    {
        public static List<int> Load(DataType dataType)
        {
            CheckIfDataExists(dataType);
            string dataTypeName = GetDataName(dataType);
            QuickSaveReader reader = QuickSaveReader.Create("Data");
            return reader.Read<List<int> >(dataTypeName);
        }

        public static void Save(DataType dataType, List<int> data)
        {
            string dataTypeName = GetDataName(dataType);
            QuickSaveWriter writer = QuickSaveWriter.Create("Data");
            writer.Write<List<int>>(dataTypeName, data);
            writer.Commit();
        }

        private static void CheckIfDataExists(DataType dataType)
        {
            string dataTypeName = GetDataName(dataType);
            QuickSaveWriter writer = QuickSaveWriter.Create("Data");
            if (!writer.Exists(dataTypeName))
            {
                List<int> data = new List<int>();
                switch (dataType)
                {
                    case DataType.Colletion:
                        data.Add(0);
                        data.Add(1);
                        data.Add(2);
                        data.Add(3);
                        data.Add(4);
                        break;

                    case DataType.Deck:
                        data.Add(0);
                        data.Add(1);
                        data.Add(2);
                        break;
                }
                Save(dataType, data);
            }
        }

        private static string GetDataName(DataType dataType)
        {
            switch(dataType)
            {
                case DataType.Colletion:
                    return "Collection";
                case DataType.Deck:
                    return "Deck";
                default:
                    Debug.Log("Save System needs name for data type (check GetDataName function)");
                    return "";
            }
        }
    }
}
