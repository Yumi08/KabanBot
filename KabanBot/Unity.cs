﻿using KabanBot.Storage;
using KabanBot.Storage.Implementations;
using Unity;
using Unity.Resolution;

namespace KabanBot
{
	public static class Unity
	{
		private static UnityContainer _container;

		public static UnityContainer Container
		{
			get
			{
				if (_container == null)
					RegisterTypes();
				return _container;
			}
		}

		public static void RegisterTypes()
		{
			_container = new UnityContainer();
			_container.RegisterType<IDataStorage, InMemoryStorage>();
		}

		public static T Resolve<T>()
		{
			return (T)Container.Resolve(typeof(T), string.Empty, new CompositeResolverOverride());
		}
	}
}
