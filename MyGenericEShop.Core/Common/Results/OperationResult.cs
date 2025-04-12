using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericEShop.Core.Common.Results
{
	/// <summary>
	/// Represents the result of an operation, providing details about success, messages, errors, and execution time.
	/// This class is used to transfer meaningful information between repositories and services.
	/// </summary>
	/// <typeparam name="T">The type of data returned by the operation.</typeparam>
	public class OperationResult<T>
	{
		public bool Success { get; set; }
		public string Message { get; set; } = "No message set!";
		public T? Data { get; set; }
		public IEnumerable<T>? DataList { get; set; }
		public Exception? Exception { get; set; }
		public DateTime ExecutionTime { get; set; } = DateTime.UtcNow;
		public OperationCode? Code { get; set; }

		// Constructors for easy instantiation
		public OperationResult() { }

		public OperationResult(bool success, string message, T? data = default, OperationCode? code = null)
		{
			Success = success;
			Message = message;
			Data = data;
			Code = code;
			ExecutionTime = DateTime.UtcNow;
		}

		public OperationResult(bool success, string message, IEnumerable<T>? dataList, OperationCode? code = null)
		{
			Success = success;
			Message = message;
			DataList = dataList;
			Code = code;
			ExecutionTime = DateTime.UtcNow;
		}
		public OperationResult(bool success, string message,Exception ex, OperationCode? code = null)
		{
			Success = success;
			Message = message;
			Exception = ex;
			Code = code;
			ExecutionTime = DateTime.UtcNow;
		}
	}
}
