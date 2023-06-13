using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Printer.Classes
{
    public class LineCrud
    {
        private const string FileName = "data.json";

        public void Create(string line, string ipAddress, int port)
        {
            List<DataItem> dataItems = ReadJsonData();
            dataItems.Add(new DataItem { Line = line, IPAddress = ipAddress, Port = port });
            WriteJsonData(dataItems);
        }

        public List<DataItem> Read()
        {
            return ReadJsonData();
        }

        public void Update(int? lineNumber, DataItem dataItem)
        {
            List<DataItem> dataItems = ReadJsonData();
            if (lineNumber >= 0 && lineNumber < dataItems.Count)
            {
                DataItem item = dataItems[(int)lineNumber];
                item.Line = dataItem.Line;
                item.IPAddress = dataItem.IPAddress;
                item.Port = dataItem.Port;
                WriteJsonData(dataItems);
            }
        }

        public void Delete(int lineNumber)
        {
            List<DataItem> dataItems = ReadJsonData();
            if (lineNumber >= 0 && lineNumber < dataItems.Count)
            {
                dataItems.RemoveAt(lineNumber);
                WriteJsonData(dataItems);
            }
        }

        private List<DataItem> ReadJsonData()
        {
            string filePath = GetFilePath();
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<DataItem>>(json);
            }

            return new List<DataItem>();
        }

        private void WriteJsonData(List<DataItem> dataItems)
        {
            string json = JsonConvert.SerializeObject(dataItems, Formatting.Indented);
            File.WriteAllText(GetFilePath(), json);
        }

        private string GetFilePath()
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderPath = Path.Combine(appDataFolder, "Splash");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            return Path.Combine(folderPath, FileName);
        }
    }
}

public class DataItem
{
    public string Line { get; set; }
    public string IPAddress { get; set; }
    public int Port { get; set; }
}