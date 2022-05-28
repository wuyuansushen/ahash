using System;
using System.Runtime;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace ahash
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string inputHash = args[0].Trim();
                const string opts = @"--bt-save-metadata=true --bt-metadata-only=true ";
                const string magnetPrefix = @"magnet:?xt=urn:btih:";
                string downloadLink=String.Empty;
                if (inputHash.StartsWith(magnetPrefix))
                {
                    downloadLink = inputHash;
                }
                else
                {
                    downloadLink =magnetPrefix+inputHash;
                }

                var aria2cProcess = Process.Start("/usr/bin/aria2c",
                    opts+downloadLink);
                aria2cProcess.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Invalid hash value.");
            }
        }
    }
}
