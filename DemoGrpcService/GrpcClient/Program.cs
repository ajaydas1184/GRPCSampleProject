using Grpc.Net.Client;
using GrpcService;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await PrintName();
            Console.ReadKey();
        }

        public static async Task PrintName()
        {
            string name;
            using var grpcChannel = GrpcChannel.ForAddress("https://localhost:5001");
            var grpcClient = new Greeter.GreeterClient(grpcChannel);
            Console.Write("Enter your name:");
            name = Console.ReadLine();
            var reply = await grpcClient.SayHelloAsync(new HelloRequest { Name = name });

            var deptClient = new RemoteDepartment.RemoteDepartmentClient(grpcChannel);

            var ret = await deptClient.AddEditRecordAsync(new DepartmentModel() { Name = "Test" });

            //var empClient = new RemoteEmployee.RemoteEmployeeClient(grpcChannel);

            //var ret = await empClient.AddEditRecordAsync(new EmployeeModel()
            //{
            //    Id = 0,
            //    FirstName = "lakshmi",
            //    LastName = "Palanivel",
            //    DateOfJoining = new DateTime(2010, 04, 11).ToString(),
            //    Gender = "Female",
            //    DepartmentId = 1,
            //    MonthlySalary = 48000,
            //    EmployeeType = "permanent"
            //});

            //foreach (var s in ret.Items)
            //{
            //    Console.WriteLine(string.Format("Id:{0}\nName:{1}", s.Id, s.Name));
            //}

            //Console.WriteLine(string.Format("{0}\n\n\nId:{1}\nName:{2}", "Deba", ret.RetVal, ret.MSG));
            //Console.WriteLine(string.Format("{0}", reply.Message));
        }
    }
}
