using System;
using System.Collections.Generic;

using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Crashes;
using Microsoft.Azure.Mobile.Analytics;

namespace SimpleUITestApp
{
	public static class AnalyticsHelpers
	{
		public static void Start()
		{
			MobileCenter.Start(typeof(Analytics), typeof(Crashes));
			Analytics.Enabled = true;
		}

		public static void TrackEvent(string trackIdentifier, IDictionary<string, string> table = null)
		{
			if (MobileCenter.Enabled && Analytics.Enabled)
				Analytics.TrackEvent(trackIdentifier, table);
		}

		public static void LogWarning(string tag, string message, Exception exception = null)
		{
			if (MobileCenter.Enabled && Analytics.Enabled)
				MobileCenterLog.Warn(tag, message, exception);
		}

		public static void LogError(string tag, string message, Exception exception = null)
		{
			if (MobileCenter.Enabled && Analytics.Enabled)
				MobileCenterLog.Error(tag, message, exception);
		}

		public static void LogInfo(string tag, string message, Exception exception = null)
		{
			if (MobileCenter.Enabled && Analytics.Enabled)
				MobileCenterLog.Info(tag, message, exception);
		}

		public static void LogDebug(string tag, string message, Exception exception = null)
		{
			if (MobileCenter.Enabled && Analytics.Enabled)
				MobileCenterLog.Debug(tag, message, exception);
		}
	}
}
