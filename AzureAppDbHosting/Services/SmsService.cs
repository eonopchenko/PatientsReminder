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

		public void SendSms(string phone)
		{
			SmsSendResult sendResult = smsClient.Send(
				from: "+64123456789",
				to: phone,
				message: "Appointment reminder"
			);

			Console.WriteLine($"Sms id: {sendResult.MessageId}");
		}

		private SmsClient? smsClient;
	}
}
