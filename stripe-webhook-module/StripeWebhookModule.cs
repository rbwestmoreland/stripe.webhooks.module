using Newtonsoft.Json;
using System;
using System.IO;
using System.Web;

namespace stripe_webhook_module
{
    public class StripeWebhookModule : IHttpModule
    {
        /// <summary>
        /// default: /stripe-webhooks
        /// </summary>
        public static string Route { get; set; }
        /// <summary>
        /// on exception encountered
        /// </summary>
        public static Action<Exception> OnException { get; set; }

        public void Init(HttpApplication context)
        {
            Route = "/stripe-webhooks";
            context.BeginRequest += context_BeginRequest;
        }

        private static void context_BeginRequest(object sender, EventArgs e)
        {
            var context = (HttpApplication)sender;

            if (context != null)
            if (context.Request.Path.Equals(Route, StringComparison.OrdinalIgnoreCase))
            if (context.Request.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    using (var reader = new StreamReader(context.Request.InputStream))
                    {
                        var requestBody = reader.ReadToEnd();
                        dynamic json = JsonConvert.DeserializeObject(requestBody);
                        HandleEvent(json);
                    }
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
                finally
                {
                    context.Response.StatusCode = 200;
                    context.Response.End();
                }
            }
        }

        private static void HandleException(Exception ex)
        {
            try
            {
                OnException(ex);
            }
            catch { }
        }

        private static void HandleEvent(dynamic json)
        {
            try
            {
                var type = (string)json.type;

                StripeEvents.Any(json, type);

                switch (type)
                {
                    case "account.updated":
                        StripeEvents.AccountUpdated(json);
                        break;
                    case "account.application.deauthorized":
                        StripeEvents.AccountApplicationDeauthorized(json);
                        break;
                    case "charge.succeeded":
                        StripeEvents.ChargeSucceeded(json);
                        break;
                    case "charge.failed":
                        StripeEvents.ChargeFailed(json);
                        break;
                    case "charge.refunded":
                        StripeEvents.ChargeRefunded(json);
                        break;
                    case "charge.dispute.created":
                        StripeEvents.ChargeDisputeCreated(json);
                        break;
                    case "charge.dispute.updated":
                        StripeEvents.ChargeDisputeUpdated(json);
                        break;
                    case "charge.dispute.closed":
                        StripeEvents.ChargeDisputeClosed(json);
                        break;
                    case "customer.created":
                        StripeEvents.CustomerCreated(json);
                        break;
                    case "customer.updated":
                        StripeEvents.CustomerUpdated(json);
                        break;
                    case "customer.deleted":
                        StripeEvents.CustomerDeleted(json);
                        break;
                    case "customer.subscription.created":
                        StripeEvents.CustomerSubscriptionCreated(json);
                        break;
                    case "customer.subscription.updated":
                        StripeEvents.CustomerSubscriptionUpdated(json);
                        break;
                    case "customer.subscription.deleted":
                        StripeEvents.CustomerSubscriptionDeleted(json);
                        break;
                    case "customer.subscription.trial_will_end":
                        StripeEvents.CustomerSubscriptionTrial_Will_End(json);
                        break;
                    case "customer.discount.created":
                        StripeEvents.CustomerDiscountCreated(json);
                        break;
                    case "customer.discount.updated":
                        StripeEvents.CustomerDiscountUpdated(json);
                        break;
                    case "customer.discount.deleted":
                        StripeEvents.CustomerDiscountDeleted(json);
                        break;
                    case "invoice.created":
                        StripeEvents.InvoiceCreated(json);
                        break;
                    case "invoice.updated":
                        StripeEvents.InvoiceUpdated(json);
                        break;
                    case "invoice.payment_succeeded":
                        StripeEvents.InvoicePayment_Succeeded(json);
                        break;
                    case "invoice.payment_failed":
                        StripeEvents.InvoicePayment_Failed(json);
                        break;
                    case "invoiceitem.created":
                        StripeEvents.InvoiceItemCreated(json);
                        break;
                    case "invoiceitem.updated":
                        StripeEvents.InvoiceItemUpdated(json);
                        break;
                    case "invoiceitem.deleted":
                        StripeEvents.InvoiceItemDeleted(json);
                        break;
                    case "plan.created":
                        StripeEvents.PlanCreated(json);
                        break;
                    case "plan.updated":
                        StripeEvents.PlanUpdated(json);
                        break;
                    case "plan.deleted":
                        StripeEvents.PlanDeleted(json);
                        break;
                    case "coupon.created":
                        StripeEvents.CouponCreated(json);
                        break;
                    case "coupon.deleted":
                        StripeEvents.CouponDeleted(json);
                        break;
                    case "transfer.created":
                        StripeEvents.TransferCreated(json);
                        break;
                    case "transfer.updated":
                        StripeEvents.TransferUpdated(json);
                        break;
                    case "transfer.failed":
                        StripeEvents.TransferFailed(json);
                        break;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Dispose()
        {
        }
    }
}
