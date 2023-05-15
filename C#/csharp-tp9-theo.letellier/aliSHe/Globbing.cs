using System;
using System.Collections.Generic;
using System.IO;

namespace AliSHe 
{
    public class Globbing
    {
        public static bool Match(string str, string pattern)
        {
            int strL = str.Length;
            int patL = pattern.Length;
            
            if (strL == 0 && patL == 0 || str == pattern)
                return true;

            if (pattern[0] == '?' || str[0] == pattern[0])
                return Match(str.Substring(1), pattern.Substring(1));

            if (pattern[0] == '*')
                return Star(str, pattern);
            
            if (str[0] != pattern[0])
                return false;
            
            return true;
        }

        public static bool Star(string str, string pattern)
        {
            pattern = pattern.Substring(1);

            while (str[0] != pattern[0] && str.Length > 0)
            {
                str = str.Substring(1);
            }

            if (str.Length == 0 && pattern.Length != 0)
                return false;
            
            return Match(str, pattern);
        }

        public static List<string> Expand(string pattern)
        {
            List<string> liste = new List<string>();
            //liste.Add(pattern);

            DirectoryInfo dir = new DirectoryInfo(
		    Directory.GetCurrentDirectory());

            foreach (DirectoryInfo element in dir.GetDirectories())
            {
		if (Match(element.Name,pattern))
           		liste.Add(element.Name);
            }
	    
	    foreach (FileInfo element in dir.GetFiles())
	    {
		if (Match(element.Name, pattern))
			liste.Add(element.Name);
	    }
            
            
            return liste;
        }
    }
}
