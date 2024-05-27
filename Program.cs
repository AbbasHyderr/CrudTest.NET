using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestCrud.Factory;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<ILog, Logs>()
             .AddSingleton<RecordSqlService>()
            .AddSingleton<CourseSqlService>()
            .BuildServiceProvider();

        var log = serviceProvider.GetService<ILog>();
        var course = serviceProvider.GetService<CourseSqlService>();
        var record = serviceProvider.GetRequiredService<IFactory>();
        var factory = serviceProvider.GetRequiredService<IFactory>();

        record.DeleteRecord();


        
        
        
       // IFactory method2 = FactoryController.GetMethod("RecordSql");
       // Console.WriteLine("Initaiting SQL");



        //method2.InsertTable();


    }
}