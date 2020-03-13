using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Threading.Tasks;

namespace part2
{
    public class WebRead   // Return Json object - can be used to build a new c# object.
    {
        static public string FormatBytes(long bytes)
        {
            string[] magnitudes =
                new string[] { "GB", "MB", "KB", "Bytes" };
            long max =
                (long)Math.Pow(1024, magnitudes.Length);

            return string.Format("{1:##.##} {0}",
                magnitudes.FirstOrDefault(
                    magnitude =>
                    bytes > (max /= 1024)) ?? "0 Bytes",
              (decimal)bytes / (decimal)max);
        }

        private static async Task WriteWebRequestSizeAsync(string url)
        {
            try
            {
                WebRequest webRequest =
                    WebRequest.Create(url);
                WebResponse response =
                    await webRequest.GetResponseAsync();
                using (StreamReader reader =
                    new StreamReader(
                        response.GetResponseStream()))
                {
                    string text =
                        await reader.ReadToEndAsync();
                    Console.WriteLine(text);
                    Console.WriteLine(
                        FormatBytes(text.Length));
                }
            }
            catch (WebException e )
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (NotSupportedException e )
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void StartingJob(string[] args)
        {
            string url = "https://restcountries.eu/rest/v2";
            if (args.Length > 0)
            {
                url = args[0];
            }

            Console.Write(url);

            Task task = WriteWebRequestSizeAsync(url);

            while (!task.Wait(100))
            {
                Console.Write(".");
            }
            // ...

        }

    }
}
