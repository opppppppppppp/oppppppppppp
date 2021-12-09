using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Composite
{
    public class FilePath : FileSystem
    {
        public List<FileSystem> folders { get; } = new List<FileSystem>();
        public List<FileItem> items = new List<FileItem>();

        public FilePath(string name) : base(name)
        {

        }

        public void AddItem(FileItem newItem)
        {
            this.items.Add(newItem);
        }

        public void Add(FileSystem newNode)
        {
            this.folders.Add(newNode);
        }
        public void Remove(FileSystem deleteNode)
        {
            this.folders.Remove(deleteNode);
        }
    }
}
