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

            // ���U Form1 �M��̿઺�A��
            builder.RegisterType<Form1>();
            builder.RegisterType<ConvertVoice>().As<IConvertVoice>();

            // �إ߮e��
            var container = builder.Build();

            // �Ұ����ε{��
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<Form1>());
            //Application.Run(new Form1());

        }
    }
}