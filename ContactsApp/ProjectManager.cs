﻿using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Класс менеджер проекта
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Имя файла для сериализации/десериализации данных проекта.
        /// Путь для сериализации/десериализации данных проекта.
        /// </summary>
        private const string FileName = "ContactsApp.notes";

        /// <summary>
        /// Путь до папки сохранения.
        /// </summary>
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/ContactApp/";

        private static string pathToFile = path + FileName;

        /// <summary>
        /// Метод сериализации данных проекта.
        /// </summary>
        public static void SaveToFile(Project project, string path)
        {
            Directory.CreateDirectory(path);
            
            path += FileName;

            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(path))
            using (JsonTextWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Метод десериализации данных проекта.
        /// </summary>
        public static Project LoadFromFile(string path)
        {
            path += FileName;

            Project project;

            JsonSerializer serializer = new JsonSerializer();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                using (JsonTextReader reader = new JsonTextReader(sr))
                project = serializer.Deserialize<Project>(reader);

                if (project == null)
                {
                    project = new Project();
                }
            }
            catch
            {
                project = new Project();
                return project;
            }
            return project;
        }
    }
}
