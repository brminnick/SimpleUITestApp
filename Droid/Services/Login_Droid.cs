﻿using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Akavache;

using Xamarin.Forms;

using SimpleUITestApp.Droid;
using Xamarin;

[assembly: Dependency(typeof(Login_Droid))]
namespace SimpleUITestApp.Droid
{
	public class Login_Droid : ILogin
	{
		public void AuthenticateWithTouchId(LoginPage page)
		{
		}

		public async Task<bool> SetPasswordForUsername(string username, string password)
		{
			await BlobCache.UserAccount.InsertObject("username", username);
			await BlobCache.UserAccount.InsertObject("password", password);

			return true;
		}

		public async Task<bool> CheckLogin(string username, string password)
		{
			string _username = null;
			string _password = null;

			try
			{
				_username = await BlobCache.UserAccount.GetObject<string>("username");
			}
			catch (Exception e)
			{
				AnalyticsHelpers.Log("No Username Stored", e.Message, e);
				return false;
			}

			try
			{
				_password = await BlobCache.UserAccount.GetObject<string>("password");
			}
			catch (Exception e)
			{
				AnalyticsHelpers.Log("No Password Store", e.Message, e);
				return false;
			}

			try
			{
				IEnumerable<string> test = await BlobCache.UserAccount.GetAllKeys();
			}
			catch (Exception e)
			{
				AnalyticsHelpers.Log("Error Getting User Account Keys", e.Message, e);
			}

			if (_username == null || _password == null)
				return false;

			if (password == _password &&
				username == _username.ToString())
			{
				return true;
			}

			return false;
		}

		public async Task SaveUsername(string username)
		{
			await BlobCache.UserAccount.InsertObject<string>("username", username);
		}

		public async Task<string> GetSavedUsername()
		{
			string username = null;
			try
			{
				username = await BlobCache.UserAccount.GetObject<string>("username");
			}
			catch (Exception e)
			{
				AnalyticsHelpers.Log("Username Not Found", e.Message, e);
			}

			return username;
		}
	}
}