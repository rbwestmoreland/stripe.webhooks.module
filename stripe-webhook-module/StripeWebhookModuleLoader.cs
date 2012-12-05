using Microsoft.Web.Infrastructure.DynamicModuleHelper;

namespace stripe_webhook_module
{
    public static class StripeWebhookModuleLoader
    {
        public static void Load()
        {
            DynamicModuleUtility.RegisterModule(typeof(StripeWebhookModule)); 
        }
    }
}
