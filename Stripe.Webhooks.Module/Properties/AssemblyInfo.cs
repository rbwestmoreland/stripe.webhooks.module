using Stripe.Webhooks.Module;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Web;

[assembly: AssemblyTitle("Stripe.Webhooks.Module")]
[assembly: AssemblyDescription("stripe.com webhook httpmodule")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Bates Westmoreland")]
[assembly: AssemblyProduct("Stripe.Webhooks.Module")]
[assembly: AssemblyCopyright("Copyright © Bates Westmoreland 2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly: Guid("ba61b46d-b088-4b14-9fa0-c3aac6d8d99f")]

[assembly: AssemblyVersion("2.0.0")]
[assembly: AssemblyFileVersion("2.0.0")]

[assembly: PreApplicationStartMethod(typeof(StripeWebhookModuleLoader), "Load")]
