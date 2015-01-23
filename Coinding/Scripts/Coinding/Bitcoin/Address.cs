#region License
/*
 * Address.cs
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
using UnityEngine;
using System.Collections;

namespace CoindingNs
{
	public class Address
	{
		#region Injected Dependencies
		
		private Transport t;
		
		#endregion
		
		#region Public interface
		
		public Address(Transport t)
		{
			this.t = t;
		}
		
		/**
		 * Returns basic balance details of a random Bitcoin address
		 */
		public void Random(Action<JSONObject> success, Action<string> error)
		{
			t.Get("bitcoin/address/random", success, error);
		}

		/**
		 * Returns basic balance details for a single Bitcoin address
		 */
		public void Get(string hash, Action<JSONObject> success, Action<string> error)
		{
			t.Get("bitcoin/address/" + hash, success, error);
		}

		/**
		 * Returns a set of transactions for a Bitcoin address
		 */
		public void Transactions(string hash, Action<JSONObject> success, Action<string> error)
		{
			t.Get("bitcoin/address/" + hash + "/transactions", success, error);
		}

		/**
		 * Returns a collection of unspent outputs for a Bitcoin address
		 */
		public void Unspents(string hash, Action<JSONObject> success, Action<string> error)
		{
			t.Get("bitcoin/address/" + hash + "/unspents", success, error);
		}
	
		#endregion
	}
}
