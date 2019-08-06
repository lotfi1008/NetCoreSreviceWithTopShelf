using System;
using Topshelf;

namespace NetCoreSreviceWithTopShelf
{
    class Program
    {
        static void Main(string[] args)
        {

            HostFactory.Run(windowsService =>
            {
                windowsService.Service<TrakDateTime>(c=> {
                    c.ConstructUsing(x =>new TrakDateTime());
                    c.WhenStarted(service => service.Start());
                    c.WhenStopped(service => service.Stop());
                });
                
                windowsService.RunAsLocalSystem();
                windowsService.StartAutomatically();

                windowsService.SetDescription("NetCoreSreviceWithTopShelfDescription");
                windowsService.SetDisplayName("NetCoreSreviceWithTopShelfDisplayName");
                windowsService.SetServiceName("NetCoreSreviceWithTopShelf");
            });

           
        }






        public class TrakDateTime
        {
            public TrakDateTime()
            {
                
            }
            public void Start()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                for (int i = 0; i < 100; i++)
                {
                    System.Threading.Thread.Sleep(1000);
                    System.IO.File.AppendAllLines(@"C://Temp/sample.txt", new string[] { DateTime.Now.ToString() });
                    Console.WriteLine("[Go] : " + DateTime.Now.ToString());
                }
            }
            public void Stop()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[Go] : [Done]");
            }
        }
    }
}
