using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace GrpcClientWebApplication.Controllers
{
    public class BaseController : Controller
    {
       protected GrpcChannel _GrpcChannel { get { return GrpcChannel.ForAddress("https://localhost:5001"); } }
    }
}
