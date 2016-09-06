//------------------------------------------------------------------------------
// <copyright file="ProvideToolboxControlAttribute.cs" company="Hewlett-Packard Company">
//     Copyright (c) Hewlett-Packard Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Microsoft.VisualStudio.Shell
{
	/// <summary>
	/// This attribute adds a ToolboxControlsInstaller key for the assembly to install toolbox controls from the assembly.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	[ComVisible(false)]
	internal sealed class ProvideToolboxControlAttribute : RegistrationAttribute
	{
		private const string ToolboxControlsInstallerPath = "ToolboxControlsInstaller";
		private readonly string tabName;

		/// <summary>
		/// Creates a new ProvideToolboxControl attribute to register the assembly for toolbox controls installer.
		/// </summary>
		/// <param name="tab">The name of the toolbox tab under which to insert the control.</param>
		public ProvideToolboxControlAttribute(string tab)
		{
			if (tab == null)
				throw new ArgumentNullException(nameof(tab));
			tabName = tab;
		}

		/// <summary>
		/// Called to register this attribute with the given context. The context
		/// contains the location where the registration information should be placed.
		/// It also contains other information such as the type being registered and path information.
		/// </summary>
		/// <param name="context">Given context to register in.</param>
		public override void Register(RegistrationContext context)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));

			using (Key key = context.CreateKey(Path.Combine(ToolboxControlsInstallerPath, context.ComponentType.Assembly.FullName)))
			{
				key.SetValue(string.Empty, tabName);
				key.SetValue("Codebase", context.CodeBase);
			}
		}

		/// <summary>
		/// Called to unregister this attribute with the given context.
		/// </summary>
		/// <param name="context">A registration context provided by an external registration tool. 
		/// The context can be used to remove registry keys, log registration activity, and obtain information
		/// about the component being registered.</param>
		public override void Unregister(RegistrationContext context)
		{
			if (context != null)
				context.RemoveKey(Path.Combine(ToolboxControlsInstallerPath, context.ComponentType.Assembly.FullName));
		}
	}
}
