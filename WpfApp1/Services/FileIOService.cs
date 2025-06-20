﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    internal class FileIOService
    {

        private readonly string PATH;

        public FileIOService(string path)
        {
            PATH = path;
        }
        public BindingList<ToDoModel> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<ToDoModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(fileText);
            }
        }

        public void SaveData(object _todoDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH)) {
                string output = JsonConvert.SerializeObject(_todoDataList);
                writer.Write(output);
            }
        }
    }
}
