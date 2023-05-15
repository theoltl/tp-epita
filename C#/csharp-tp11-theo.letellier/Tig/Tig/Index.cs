using System.Collections.Generic;
using System.IO;
using System;
using System.Reflection.Metadata;

namespace Tig
{
    // Threshold 1
    public class Index
    {
        public class Entry
        { 
            private string path;
            private string hash;
            private int size;
            
            

            public Entry(string path, string hash, int size)
            {
                this.path = path;
                this.size = size;
                this.hash = hash;
            }

            public string Path
            {
                get => path;
                set => path = value;
            }

            public string Hash
            {
                get => hash;
                set => hash = value;
            }

            public int Size
            {
                get => size;
                set => size = value;
            }
        }

        // TODO: add Index attributes

        // TODO: add Index constructor
        public Index()
        {
            ReadIndex();
        }

        // TODO: add Index getter
        private List<Entry> entries;

        public List<Entry> Entries
        {
            get => entries;
            set => entries = value;
        }

        public void ReadIndex()
        {
            string path = ".tig/index";
            string[] texte = File.ReadAllLines(path);
            for (int i = 0; i < texte.Length; i++)
            {
                string [] ligne = texte[i].Split(" ");
                entries[i] = new Entry(ligne[0], ligne[1], int.Parse(ligne[2]));
            }
        }

        public void WriteIndex()
        {
            string path = ".tig/index";
            File.Delete(path);
            var fichier = File.Create(path);
            TextWriter txt = new StreamWriter(path, true);
            for (int i = 0; i < Entries.Count; i++)
            {
                txt.WriteLine("{0} {1} {2}", entries[0], entries[1], entries[2]);
            }
            fichier.Close();
        }

        public void AddEntry(string path, string hash, int size)
        {
            bool replace = false;
            for (int i = 0; i < Entries.Count; i++)
            {
                if (entries[i].Path == path)
                {
                    entries[i].Hash = hash;
                    entries[i].Size = size;
                    replace = true;
                }
            }
            if (!replace)
                entries.Add(new Entry(path,hash,size));
        }

        public Entry GetEntry(string path)
        {
            foreach (Entry entry in entries)
            {
                if (entry.Path == path)
                    return entry;
            }
            return null;
        }
    }
}
