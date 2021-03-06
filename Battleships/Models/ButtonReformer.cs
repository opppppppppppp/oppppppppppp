using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Composite
{
    public class ButtonReformer
    {
        private static string workingDirectory = Environment.CurrentDirectory;
        private static string path = Directory.GetParent(workingDirectory).Parent.FullName + "\\Images";
        public static FilePath root = new FilePath(path);
        public static void SetupFiles()
        {
            var folder1 = new FilePath("\\MainButtons");

            folder1.AddItem(new FileItem("\\btn_img_1.png"));
            folder1.AddItem(new FileItem("\\btn_img_2.png"));
            folder1.AddItem(new FileItem("\\btn_img_3.png"));

            root.Add(folder1);

            var subfolder = new FilePath("\\SecondaryButtons");
            subfolder.AddItem(new FileItem("\\btn_img_4.png"));
            subfolder.AddItem(new FileItem("\\btn_img_5.png"));
            subfolder.AddItem(new FileItem("\\btn_img_6.png"));

            folder1.Add(subfolder);
        }

        public static string RandomFolderPath()
        {
            SetupFiles();
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            var folder = root.folders[rnd.Next(0, root.folders.Count)] as FilePath;
            return root.Name + folder.Name + folder.items[rnd.Next(0, folder.items.Count())].Name;
        }

        public static string RandomSubfolderPath()
        {
            SetupFiles();
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            var folder = root.folders[rnd.Next(0, root.folders.Count)] as FilePath;
            var subfolder = folder.folders[rnd.Next(0, folder.folders.Count)] as FilePath;
            return root.Name + folder.Name + subfolder.Name + subfolder.items[rnd.Next(0, subfolder.items.Count())].Name;
        }
    }
}
