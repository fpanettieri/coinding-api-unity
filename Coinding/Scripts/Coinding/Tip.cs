#region License
/*
 * Tip.cs
 *
 * The MIT License
 *
 * Copyright (c) 2014 Fabio Panettieri
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
	public class Tip
	{
		#region Injected Dependencies
		
		private Transport t;
		
		#endregion
		
		#region Public interface
		
		public Tip(Transport t)
		{
			this.t = t;
		}

		/**
		 * Authenticated resource which allows a player send money to another player
		 */
		public void PlayerToPlayer(string name, string pass, double amount, string to, Action<JSONObject> success, Action<string> error)
		{
			WWWForm form = new WWWForm();
			form.AddField("name", pass);
			form.AddField("pass", Util.Encrypt(pass));
			form.AddField("amount", amount.ToString("n8"));
			form.AddField("to", to);
			t.Get("tip/player2player", form, success, error);
		}

		/**
		 * Authenticated resource which allows a player send money to a game developer
		 */
		public void PlayerToDeveloper(string name, string pass, double amount, string to, Action<JSONObject> success, Action<string> error)
		{
			WWWForm form = new WWWForm();
			form.AddField("name", pass);
			form.AddField("pass", Util.Encrypt(pass));
			form.AddField("amount", amount.ToString("n8"));
			form.AddField("to", to);
			t.Get("tip/player2player", form, success, error);
		}

		/**
		 * Authenticated resource which allows a developer send money to a player
		 */
		public void DeveloperToPlayer(string name, string pass, double amount, string to, Action<JSONObject> success, Action<string> error)
		{
			WWWForm form = new WWWForm();
			form.AddField("name", pass);
			form.AddField("pass", Util.Encrypt(pass));
			form.AddField("amount", amount.ToString("n8"));
			form.AddField("to", to);
			t.Get("tip/player2player", form, success, error);
		}

		#endregion
	}
}
