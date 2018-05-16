using System;
using System.Collections.Generic;

namespace KabanBot.Storage.Implementations
{
	public class InMemoryStorage : IDataStorage
	{
		private readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();

		public void StoreObject(string key, object obj)
		{
			if (!_dictionary.ContainsKey(key))
			{
				_dictionary.Add(key, obj);
				return;
			}

			_dictionary[key] = obj;
		}

		public T RestoreObject<T>(string key)
		{
			if (!_dictionary.ContainsKey(key))
				throw new ArgumentException($"Provided key '{key}' was not found.");

			return (T) _dictionary[key];
		}
	}
}
