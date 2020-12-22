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

            //var deptClient = new RemoteDepartment.RemoteDepartmentClient(grpcChannel);
            //var ret = await deptClient.GetDepartmentInfoAsync(new DepartmentRequest() { Id = 2 });
            
            Console.WriteLine(string.Format("{0}", reply.Message));
        }
    }
}
