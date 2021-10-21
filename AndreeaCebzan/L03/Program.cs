using System;

namespace L03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static void Initialize()
        {
            string[] scopes = new string[] {
                DriveService.Scope.Drive,
                DriveService,scopes.DriveFiles
            };
            var clientId= "900405440191-5u2lq1s1fo1vji1iab3vd9b1krubnmoh.apps.googleusercontent.com";
            var clientSecret="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";
            var credential= GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId= clientId,
                    ClientSecret=clientSecret
                },
                scopes,
                Environment.UserName,
                CancellationToken.None,

                new FileDataStore("Daimto.GoogleDrive.Auth.Store4")
            ).Result;
            _service=new DriverService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer= credential
            });
            _token = credential.Token.AccessToken;
            Console.Write("Token: " + credential.Token.AccessToken); 
           
        }
    }
}