using System;
using System.Collections.Generic;

using Azure;
using Azure.Communication;
using Azure.Communication.Sms;

namespace AzureAppDbHosting.Services
{
	public class SmsService
	{
		public SmsService(string connectionString)
		{
			smsClient = new SmsClient(connectionString);
		}

		public string SendSms(string phone, string notification)
		{
			SmsSendResult sendResult = smsClient.Send(
				from: "+64123456789",
				to: phone,
				message: notification
			);

			Console.WriteLine($"Sms id: {sendResult.MessageId}");

			return sendResult.ToString();
		}

		private SmsClient? smsClient;
	}
}
