﻿using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace Utilities;

public static class TempDataHelper
{
	/// <summary>
	/// Puts an object into the TempData by first serializing it to JSON.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="tempData"></param>
	/// <param name="key"></param>
	/// <param name="value"></param>
	public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
	{
		string? result = JsonConvert.SerializeObject(value);
		tempData[key] = result;
	}

	/// <summary>
	/// Gets an object from the TempData by deserializing it from JSON.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="tempData"></param>
	/// <param name="key"></param>
	/// <returns></returns>
	public static T? Get<T>(this ITempDataDictionary tempData, string key) where T : class
	{
		object? o;
		tempData.TryGetValue(key, out o);

		string? resultTextJson = o?.ToString();

		// T? result = (o == null) ? null : JsonConvert.DeserializeObject<T>(resultTextJson);

		T? result = string.IsNullOrEmpty(resultTextJson) == true
			? null
			: JsonConvert.DeserializeObject<T>(resultTextJson);

		return result;
	}
}