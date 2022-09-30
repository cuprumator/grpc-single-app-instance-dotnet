# grpc-single-app-instance-dotnet
Single app instance arguments sending service for .NET apps.

## Usage
1. Implement SingleInstance.SingleInstanceBase with method SendArgs which perform args processing.
2. Start server on app sturtup.\
For example OnStartup method of WPF app:
    ```csharp
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        this.singleInstanceServiceServer = new SingleInstanceServiceServer(new SingleInstantServiceImpl());
        this.singleInstanceServiceServer.Start();

        this.mainView.Show();
    }
    ```
3. Send args from app main method.\
For example main method of explicit Programm class of WPF app:
    ```csharp
    public static class Program
    {
        private static Mutex? processMutex;

        [STAThread]
        public static void Main(string[] args)
        {
            processMutex = new Mutex(true, "AwesomeWPFApp", out var isNewInstance);
            if (!isNewInstance)
            {
                SingleInstanceServiceClient.SendArgs(args, out var replyMessage);
                return;
            }

            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
    ```
See test project fot details.