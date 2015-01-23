#region License
/*
 * Developer.cs
 *
 * The MIT License
 *
 * Copyright (c) 2015 Fabio Panettieri
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
#endregion

using System;
using System.Collections;
using UnityEngine;

namespace CoindingNs
{
	public class Developer
	{
		#region Injected Dependencies
		
		private Transport t;
		
		#endregion

		#region Public interface
		
		public Developer(Transport t)
		{
			this.t = t;
		}

		/**
		 * Returns a list with the name of registered developers.
		 */
		public void GetAll(Action<JSONObject> success, Action<string> error)
		{
			t.Get("developer", success, error);
		}

		/**
		 * Creates a new developer account
		 */
		public void Register(string name, string email, string pass, Action<JSONObject> success, Action<string> error)
		{
			WWWForm form = new WWWForm();
			form.AddField("name", name);
			form.AddField("email", email);
			form.AddField("pass", Util.Encrypt(pass));
			t.Post("developer/register", form, success, error);
		}

		/**
		 * Authenticated resource which returns the current balance of the developer in Bitcoins
		 */
		public void Balance(string email, string pass, Action<JSONObject> success, Action<string> error)
		{
			WWWForm form = new WWWForm();
			form.AddField("email", email);
			form.AddField("pass", Util.Encrypt(pass));
			t.Get("developer/balance", form, success, error);
		}

		/**
		 * Authenticated resource which returns the current balance of the developer in Bitcoins
		 */
		public void WithdrawFunds(string email, string pass, double amount, string to, Action<JSONObject> success, Action<string> error)
		{
			WWWForm form = new WWWForm();
			form.AddField("email", email);
			form.AddField("pass", Util.Encrypt(pass));
			form.AddField("amount", amount.ToString("n8"));
			form.AddField("to", to);
			t.Get("developer/withdraw", form, success, error);
		}

		#endregion
	}
}
