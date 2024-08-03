using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
	public class HashKeyGenerator
	{
		public async Task<string> CreateHashKey()
		{
			int keySize = 32;
			var key = new byte[keySize];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(key);
			}

			StringBuilder hex = new StringBuilder(keySize*2);
			foreach (byte b in key) { hex.AppendFormat("0:x2", b); }

			return hex.ToString();
		}
	}
}
