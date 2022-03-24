using System;
using System.Runtime;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace ahash
{
    public class Program
    {
        public static void Main()
        {
            Console.Write($"Input torrent hash:");
            string inputHash = ((Console.ReadLine()) ?? throw new ArgumentNullException());
            try
            {
                var aria2cProcess = Process.Start("/usr/bin/aria2c", "--bt-save-metadata=true --bt-metadata-only=true magnet:?xt=urn:btih:" + inputHash);
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
