// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/Employee.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcService {
  /// <summary>
  /// The Department service definition.
  /// </summary>
  public static partial class RemoteEmployee
  {
    static readonly string __ServiceName = "employeePackage.RemoteEmployee";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::GrpcService.FilterRequest> __Marshaller_employeePackage_FilterRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcService.FilterRequest.Parser));
    static readonly grpc::Marshaller<global::GrpcService.EmployeeModel> __Marshaller_employeePackage_EmployeeModel = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcService.EmployeeModel.Parser));
    static readonly grpc::Marshaller<global::GrpcService.EmployeesResponse> __Marshaller_employeePackage_EmployeesResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcService.EmployeesResponse.Parser));
    static readonly grpc::Marshaller<global::GrpcService.EmployeeResponse> __Marshaller_employeePackage_EmployeeResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcService.EmployeeResponse.Parser));

    static readonly grpc::Method<global::GrpcService.FilterRequest, global::GrpcService.EmployeeModel> __Method_GetEmployeeInfo = new grpc::Method<global::GrpcService.FilterRequest, global::GrpcService.EmployeeModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetEmployeeInfo",
        __Marshaller_employeePackage_FilterRequest,
        __Marshaller_employeePackage_EmployeeModel);

    static readonly grpc::Method<global::GrpcService.FilterRequest, global::GrpcService.EmployeesResponse> __Method_GetEmployeeList = new grpc::Method<global::GrpcService.FilterRequest, global::GrpcService.EmployeesResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetEmployeeList",
        __Marshaller_employeePackage_FilterRequest,
        __Marshaller_employeePackage_EmployeesResponse);

    static readonly grpc::Method<global::GrpcService.EmployeeModel, global::GrpcService.EmployeeResponse> __Method_AddEditRecord = new grpc::Method<global::GrpcService.EmployeeModel, global::GrpcService.EmployeeResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddEditRecord",
        __Marshaller_employeePackage_EmployeeModel,
        __Marshaller_employeePackage_EmployeeResponse);

    static readonly grpc::Method<global::GrpcService.FilterRequest, global::GrpcService.EmployeeResponse> __Method_DeleteRecord = new grpc::Method<global::GrpcService.FilterRequest, global::GrpcService.EmployeeResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteRecord",
        __Marshaller_employeePackage_FilterRequest,
        __Marshaller_employeePackage_EmployeeResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcService.EmployeeReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for RemoteEmployee</summary>
    public partial class RemoteEmployeeClient : grpc::ClientBase<RemoteEmployeeClient>
    {
      /// <summary>Creates a new client for RemoteEmployee</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public RemoteEmployeeClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for RemoteEmployee that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public RemoteEmployeeClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected RemoteEmployeeClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected RemoteEmployeeClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::GrpcService.EmployeeModel GetEmployeeInfo(global::GrpcService.FilterRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetEmployeeInfo(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::GrpcService.EmployeeModel GetEmployeeInfo(global::GrpcService.FilterRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetEmployeeInfo, null, options, request);
      }
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::GrpcService.EmployeeModel> GetEmployeeInfoAsync(global::GrpcService.FilterRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetEmployeeInfoAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::GrpcService.EmployeeModel> GetEmployeeInfoAsync(global::GrpcService.FilterRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetEmployeeInfo, null, options, request);
      }
      public virtual global::GrpcService.EmployeesResponse GetEmployeeList(global::GrpcService.FilterRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetEmployeeList(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::GrpcService.EmployeesResponse GetEmployeeList(global::GrpcService.FilterRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetEmployeeList, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::GrpcService.EmployeesResponse> GetEmployeeListAsync(global::GrpcService.FilterRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetEmployeeListAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::GrpcService.EmployeesResponse> GetEmployeeListAsync(global::GrpcService.FilterRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetEmployeeList, null, options, request);
      }
      public virtual global::GrpcService.EmployeeResponse AddEditRecord(global::GrpcService.EmployeeModel request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddEditRecord(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::GrpcService.EmployeeResponse AddEditRecord(global::GrpcService.EmployeeModel request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_AddEditRecord, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::GrpcService.EmployeeResponse> AddEditRecordAsync(global::GrpcService.EmployeeModel request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddEditRecordAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::GrpcService.EmployeeResponse> AddEditRecordAsync(global::GrpcService.EmployeeModel request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_AddEditRecord, null, options, request);
      }
      public virtual global::GrpcService.EmployeeResponse DeleteRecord(global::GrpcService.FilterRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteRecord(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::GrpcService.EmployeeResponse DeleteRecord(global::GrpcService.FilterRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DeleteRecord, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::GrpcService.EmployeeResponse> DeleteRecordAsync(global::GrpcService.FilterRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteRecordAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::GrpcService.EmployeeResponse> DeleteRecordAsync(global::GrpcService.FilterRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DeleteRecord, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override RemoteEmployeeClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new RemoteEmployeeClient(configuration);
      }
    }

  }
}
#endregion