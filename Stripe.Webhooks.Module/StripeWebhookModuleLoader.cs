using Microsoft.Web.Infrastructure.DynamicModuleHelper;

namespace Stripe.Webhooks.Module
{
    public static class StripeWebhookModuleLoader
    {
        public static void Load()
        {
            DynamicModuleUtility.RegisterModule(typeof(StripeWebhookModule)); 
        }
    }
}
