﻿//===============================================================================
// Microsoft patterns & practices
// Unity Application Block
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using Microsoft.Practices.Unity;
using StopLight.ServiceImplementations;
using StopLight.ServiceInterfaces;

namespace StopLight.Logic
{
	public enum StoplightColors
	{
		Green,
		Yellow,
		Red
	}

	public class LightChangedEventArgs : EventArgs
	{
		private StoplightColors currentColor;

		public StoplightColors CurrentColor
		{
			get { return currentColor; }
			private set { currentColor = value; }
		}

		public LightChangedEventArgs(StoplightColors color)
		{
			CurrentColor = color;
		}
	}

	public delegate void StoplightChangedHandler(object sender, LightChangedEventArgs e);

	public class Stoplight
	{
		public const StoplightColors Green = StoplightColors.Green;
		public const StoplightColors Yellow = StoplightColors.Yellow;
		public const StoplightColors Red = StoplightColors.Red;

		private StoplightColors currentColor = StoplightColors.Green;
		private ILogger logger = new NullLogger();
		public event StoplightChangedHandler Changed;

		public StoplightColors CurrentColor
		{
			get { return currentColor; }
		}

		[Dependency]
		public ILogger Logger
		{
			get { return logger; }
			set { logger = value; }
		}

		public void Next()
		{
			++currentColor;
			if(currentColor > StoplightColors.Red)
			{
				currentColor = StoplightColors.Green;
			}
			RaiseChanged();
			logger.Write(string.Format("LIGHT CHANGED TO {0}", currentColor));
		}

		protected void RaiseChanged()
		{
			StoplightChangedHandler handlers = Changed;
			if(handlers != null)
			{
				LightChangedEventArgs e = new LightChangedEventArgs(currentColor);
				handlers(this, e);
			}
		}
	}
}
