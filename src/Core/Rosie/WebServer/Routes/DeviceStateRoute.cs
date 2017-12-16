﻿using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Rosie.Server;
namespace Rosie.Server.Routes
{

	[Path("api/{deviceId}/State")]
	public class DeviceRoute : Route<DeviceState>
	{
		public DeviceRoute()
		{
		}

		public override Task<DeviceState> GetResponse(HttpMethod method, HttpListenerRequest request, NameValueCollection queryString, string data)
		{
			var deviceId = queryString["deviceId"];
			if (method == HttpMethod.Get)
				return GetDeviceState(deviceId);
			else if (method == HttpMethod.Post)
				return SetDeviceState(deviceId,data.ToObject<DeviceState>());
			throw new NotSupportedException($"Not supported HttpMethod: {method.Method}");
		}

		async Task<DeviceState> SetDeviceState(string deviceId, DeviceState state)
		{
			throw new NotSupportedException();
		}
		Task<DeviceState> GetDeviceState(string deviceId)
		{
			return DeviceDatabase.Shared.GetDeviceState(deviceId);
		}


		public override HttpMethod[] GetSupportedMethods() => new HttpMethod[] { HttpMethod.Get, HttpMethod.Post };
	}
}