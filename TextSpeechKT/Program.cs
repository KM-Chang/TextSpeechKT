using Autofac;
using TextSpeechKT.Server;

namespace TextSpeechKT
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var builder = new ContainerBuilder();

            // 註冊 Form1 和其依賴的服務
            builder.RegisterType<Form1>();
            builder.RegisterType<ConvertVoice>().As<IConvertVoice>();

            // 建立容器
            var container = builder.Build();

            // 啟動應用程式
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<Form1>());
            //Application.Run(new Form1());

        }
    }
}