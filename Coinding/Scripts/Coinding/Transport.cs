#region License
/*
 * Transport.cs
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
using System.Collections.Generic;
using UnityEngine;

namespace CoindingNs
{
	public class Transport : MonoBehaviour
	{
		#region Public Interface

		public string api = "http://api.coinding.com/";

		#endregion

		#region Public Interface

		public void Get(string url, Action<JSONObject> success, Action<string> error)
		{
			WWW www = new WWW(api + url);
			StartCoroutine(WaitForRequest(www, success, error));
		}

		public void Get(string url, WWWForm form, Action<JSONObject> success, Action<string> error)
		{
			WWW www = new WWW(api + url, form);
			StartCoroutine(WaitForRequest(www, success, error));
		}

		public void Post(string url, Action<JSONObject> success, Action<string> error)
		{
			WWWForm form = new WWWForm();
			WWW www = new WWW(api + url, form);
			
			StartCoroutine(WaitForRequest(www, success, error));
		}

		public void Post(string url, WWWForm form, Action<JSONObject> success, Action<string> error)
		{
			WWW www = new WWW(api + url, form);
			StartCoroutine(WaitForRequest(www, success, error));
		}

		#endregion

		#region Private Methods

		private IEnumerator WaitForRequest(WWW www, Action<JSONObject> success, Action<string> error)
		{
			yield return www;
				
			if (www.error == null) {
				try{
					JSONObject json = new JSONObject(www.text);
					success.Invoke(json);

				} catch(Exception ex){
					Debug.LogException(ex);
				}
			
			} else {
				error.Invoke(www.error);
			}
		}

		#endregion
		
	}
}
