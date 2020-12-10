// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/Department.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcService {
  /// <summary>
  /// The Department service definition.
  /// </summary>
  public static partial class RemoteDepartment
  {
    static readonly string __ServiceName = "departmentPackage.RemoteDepartment";

    static readonly grpc::Marshaller<global::GrpcService.DepartmentRequest> __Marshaller_departmentPackage_DepartmentRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcService.DepartmentRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::GrpcService.DepartmentModel> __Marshaller_departmentPackage_DepartmentModel = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcService.DepartmentModel.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::GrpcService.DepartmentsResponse> __Marshaller_departmentPackage_DepartmentsResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcService.DepartmentsResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::GrpcService.DepartmentResponse> __Marshaller_departmentPackage_DepartmentResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcService.DepartmentResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::GrpcService.DepartmentRequest, global::GrpcService.DepartmentModel> __Method_GetDepartmentInfo = new grpc::Method<global::GrpcService.DepartmentRequest, global::GrpcService.DepartmentModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetDepartmentInfo",
        __Marshaller_departmentPackage_DepartmentRequest,
        __Marshaller_departmentPackage_DepartmentModel);

    static readonly grpc::Method<global::GrpcService.DepartmentRequest, global::GrpcService.DepartmentsResponse> __Method_GetDepartmentList = new grpc::Method<global::GrpcService.DepartmentRequest, global::GrpcService.DepartmentsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetDepartmentList",
        __Marshaller_departmentPackage_DepartmentRequest,
        __Marshaller_departmentPackage_DepartmentsResponse);

    static readonly grpc::Method<global::GrpcService.DepartmentModel, global::GrpcService.DepartmentResponse> __Method_AddEditRecord = new grpc::Method<global::GrpcService.DepartmentModel, global::GrpcService.DepartmentResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddEditRecord",
        __Marshaller_departmentPackage_DepartmentModel,
        __Marshaller_departmentPackage_DepartmentResponse);

    static readonly grpc::Method<global::GrpcService.DepartmentRequest, global::GrpcService.DepartmentResponse> __Method_DeleteRecord = new grpc::Method<global::GrpcService.DepartmentRequest, global::GrpcService.DepartmentResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteRecord",
        __Marshaller_departmentPackage_DepartmentRequest,
        __Marshaller_departmentPackage_DepartmentResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcService.DepartmentReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of RemoteDepartment</summary>
    [grpc::BindServiceMethod(typeof(RemoteDepartment), "BindService")]
    public abstract partial class RemoteDepartmentBase
    {
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::GrpcService.DepartmentModel> GetDepartmentInfo(global::GrpcService.DepartmentRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::GrpcService.DepartmentsResponse> GetDepartmentList(global::GrpcService.DepartmentRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::GrpcService.DepartmentResponse> AddEditRecord(global::GrpcService.DepartmentModel request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::GrpcService.DepartmentResponse> DeleteRecord(global::GrpcService.DepartmentRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(RemoteDepartmentBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetDepartmentInfo, serviceImpl.GetDepartmentInfo)
          .AddMethod(__Method_GetDepartmentList, serviceImpl.GetDepartmentList)
          .AddMethod(__Method_AddEditRecord, serviceImpl.AddEditRecord)
          .AddMethod(__Method_DeleteRecord, serviceImpl.DeleteRecord).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, RemoteDepartmentBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetDepartmentInfo, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcService.DepartmentRequest, global::GrpcService.DepartmentModel>(serviceImpl.GetDepartmentInfo));
      serviceBinder.AddMethod(__Method_GetDepartmentList, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcService.DepartmentRequest, global::GrpcService.DepartmentsResponse>(serviceImpl.GetDepartmentList));
      serviceBinder.AddMethod(__Method_AddEditRecord, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcService.DepartmentModel, global::GrpcService.DepartmentResponse>(serviceImpl.AddEditRecord));
      serviceBinder.AddMethod(__Method_DeleteRecord, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcService.DepartmentRequest, global::GrpcService.DepartmentResponse>(serviceImpl.DeleteRecord));
    }

  }
}
#endregion
