using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Models;


namespace L04
{
    class Program
    { 
      private static CloudTableClient tableClient;
      private static CloudTable studentsTable;
        static void Main(string[] args)
        {
          Task.Run(async() => { await Initialize(); })
          .GetAwaiter()
          .GetResult();
        }
        static async Task Initialize()
        {
            string storageConnectionString="DefaultEndpointsProtocol=https;"
            + "AccountName=azurestoragel04"
            + ";AccountKey=8bRJWtBL7xgMehXUBTn25LOxPQLz8fHuUG8ZAyIxWyByi7aOWbxDwL4pHQLDtpHwgevclUth0Cnguwq2E0pIPA=="
            + ";EndpointSuffix=core.windows.net";

          var account = CloudStorageAccount.Parse(storageConnectionString);
          tableClient = account.CreateCloudTableClient();

          studentsTable=tableClient.GetTableReference("studenti");

          await studentsTable.CreateIfNotExistsAsync();
            
          await AddNewStudent();
          //await EditStudents();
          //await DeleteStudents();
          await GetAllStudents();
        }

        private static async Task GetAllStudents(){
          Console.WriteLine("Universitate\tCNP\tNume\tPrenume\tEmail\tNumar telefon\tAn");
          TableQuery<StudentEntity> query= new TableQuery<StudentEntity>();

          TableContinuationToken token = null;
          do{
            TableQuerySegment<StudentEntity> resultSegment = await studentsTable.ExecuteQuerySegmentedAsync(query,token);
            token= resultSegment.ContinuationToken;

            foreach( StudentEntity entity in resultSegment)
            {
              Console.WriteLine("{0}\t{1}\t{2} {3}\t{4}\t{5}\t{6}",  entity.PartitionKey, entity.RowKey, entity.FirstName,entity.LastName,entity.Email,
              entity.PhoneNumber,entity.Year);
            }
          }while (token!= null);
        }
        private static async Task AddNewStudent()
        { var student =  new StudentEntity("UPT", "2991233895080");
        student.FirstName="Andreea";
        student.LastName="Cebzan";
        student.Email="andreea.cebzan@gmail.com";
        student.Year=4;
        student.PhoneNumber="0783436987";
        student.Faculty="AC";
        
        var insertOperation = TableOperation.Insert(student);

        await studentsTable.ExecuteAsync(insertOperation);

        }
     
    }
}