using System.Text.Json.Serialization;

namespace Vue3_Vite.Entities
{
	public class ResultInfo
	{
		/// <summary>
		/// 状态码
		/// </summary>
		[JsonPropertyName("code")]
		public int Code { get; set; } = 0;

		/// <summary>
		/// 内容
		/// </summary>

		[JsonPropertyName("data")]
		public object Data { get; set; } = null;

		/// <summary>
		/// 错误信息
		/// </summary>
		[JsonPropertyName("msg")]
		public string Message { get; set; } = string.Empty;

		/// <summary>
		/// 是否成功
		/// </summary>
		[JsonPropertyName("success")]
		public bool IsSuccess { get; set; } = false;
	}
}