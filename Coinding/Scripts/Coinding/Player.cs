#region License
/*
 * Player.cs
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
	public class Player
	{
		#region Injected Dependencies
		
		private Transport t;
		
		#endregion
		
		#region Public interface
		
		public Player(Transport t)
		{
			this.t = t;
		}
		
		/**
		 * Returns a list with the name of registered players.
		 */
		public void GetAll(Action<JSONObject> success, Action<string> error)
		{
			t.Get("player", success, error);
		}
		
		/**
		 * Creates a new player account
		 */
		public void Register(string name, string pass, Action<JSONObject> success, Action<string> error)
		{
			WWWForm form = new WWWForm();
			form.AddField("name", name);
			form.AddField("pass", Util.Encrypt(pass));
			t.Post("player/register", form, success, error);
		}
		
		/**
		 * Authenticated resource which returns the current balance of the player in Bitcoins
		 */
		public void Balance(string name, string pass, Action<JSONObject> success, Action<string> error)
		{
			WWWForm form = new WWWForm();
			form.AddField("name", name);
			form.AddField("pass", Util.Encrypt(pass));
			t.Get("player/balance", form, success, error);
		}
		
		/**
		 * Authenticated resource which returns the current balance of the player in Bitcoins
		 */
		public void WithdrawFunds(string name, string pass, double amount, string to, Action<JSONObject> success, Action<string> error)
		{
			WWWForm form = new WWWForm();
			form.AddField("name", pass);
			form.AddField("pass", Util.Encrypt(pass));
			form.AddField("amount", amount.ToString("n8"));
			form.AddField("to", to);
			t.Get("player/withdraw", form, success, error);
		}
		
		#endregion

	}
}
